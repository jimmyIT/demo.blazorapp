using FluentResults;
using Flurl.Http.Configuration;
using Microsoft.Extensions.Options;
using Source.Shared.Common.FlurlAPIConfiguration;
using Source.Shared.Models;

namespace WebApp.Application.Processors.Identity.SignIn;

public interface ISignInProcessor
{
    Task<Result<SignInProcessorResult>> DoActionAsync(SignInProcessorModel model, CancellationToken cancellationToken = default!);
}

public class SignInProcessor(
    IOptions<WebApiSettings> apiConfigurationOption,
    IFlurlClientCache flurlClientCache)
    : FlurlAPIBaseService(apiConfigurationOption, flurlClientCache), ISignInProcessor
{
    public Task<Result<SignInProcessorResult>> DoActionAsync(
        SignInProcessorModel model,
        CancellationToken cancellationToken = default!)
    {
        return Task.FromResult(Result.Ok(new SignInProcessorResult()));
    }
}
