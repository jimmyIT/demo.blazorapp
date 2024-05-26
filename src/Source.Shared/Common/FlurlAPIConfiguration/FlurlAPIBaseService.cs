using Flurl.Http;
using Microsoft.Extensions.Options;
using Source.Shared.Models;
using System.Data;
using Source.Shared.Wrapper;
using Flurl.Http.Configuration;

namespace Source.Shared.Common.FlurlAPIConfiguration;

public class FlurlAPIBaseService
{
    protected readonly IFlurlClient _flurlClient;
    private string _token = string.Empty;
    protected FlurlAPIBaseService(
        IOptions<WebApiSettings> apiConfigurationOption,
        IFlurlClientCache flurlClientCache)
    {
        WebApiSettings serviceDetails = apiConfigurationOption.Value;
        if (serviceDetails == null
            || string.IsNullOrEmpty(serviceDetails.ApiUrl))
        {
            throw new NoNullAllowedException(nameof(serviceDetails.ApiUrl));
        }

        _flurlClient = flurlClientCache.Get(serviceDetails.ApiName);
        _flurlClient.WithTimeout(600)
                    .AllowAnyHttpStatus();
    }
    
    protected async Task<WrapperResult<TResponse>> GetAsync<TResponse>(string url, CancellationToken cancellationToken = default!)
    {
        var result = await _flurlClient
            .Request(url)
            .AllowAnyHttpStatus()
            .GetAsync(cancellationToken: cancellationToken)
            .AsResultAsync<TResponse>();

        return result;
    }

    protected async Task<WrapperResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request, string? idempotencyKey, CancellationToken cancellationToken = default!)
    {
        var result = await _flurlClient
            .Request(url)
            .WithHeader("x-idempotency-key", idempotencyKey ?? $"{Guid.NewGuid().ToString("N").Substring(0, 6)}")
            .WithOAuthBearerToken(_token)
            .AllowAnyHttpStatus()
            .PostJsonAsync(request, cancellationToken: cancellationToken)
            .AsResultAsync<TResponse>();

        return result;
    }

    protected async Task<WrapperResult<TResponse>?> PutAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken = default!)
    {
        var result = await _flurlClient
            .Request(url)
            .WithHeader("x-idempotency-key", $"{Guid.NewGuid().ToString("N").Substring(0, 6)}")
            .WithOAuthBearerToken(_token)
            .AllowAnyHttpStatus()
            .PutJsonAsync(request, cancellationToken: cancellationToken).AsResultAsync<TResponse>();

        return result;
    }

    protected async Task<WrapperResult<TResponse>?> DeleteAsync<TResponse>(string url, string? idempotencyKey, CancellationToken cancellationToken = default!)
    {
        var result = await _flurlClient
            .Request(url)
            .WithHeader("x-idempotency-key", idempotencyKey ?? $"{Guid.NewGuid().ToString("N").Substring(0, 6)}")
            .WithOAuthBearerToken(_token)
            .AllowAnyHttpStatus()
            .DeleteAsync(cancellationToken: cancellationToken)
            .AsResultAsync<TResponse>();

        return result;
    }
}
