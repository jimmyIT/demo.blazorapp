using Source.Shared.Wrapper;
using System.Net.Http.Json;
using System.Net;
using System.Text.Json;
using Flurl.Http;
using Mapster;

namespace Source.Shared.Common.FlurlAPIConfiguration;

public static class APIResultExtension
{
    public const string ApiErrorKey = "ApiError";
    public const string ApiStatusCode = "ApiStatusCode";

    public static async Task<WrapperResult<T>> AsResultAsync<T>(this Task<HttpResponseMessage> responseTask)
    {
        using HttpResponseMessage response = await responseTask.ConfigureAwait(false);
        return await response.AsResultAsync<T>();
    }

    public static async Task<WrapperResult<T>> AsResultAsync<T>(this Task<IFlurlResponse> flurlResponseTask)
    {
        using IFlurlResponse flurlResponse = await flurlResponseTask.ConfigureAwait(false);
        using HttpResponseMessage response = flurlResponse.ResponseMessage;
        return await response.AsResultAsync<T>();
    }

    public static async Task<WrapperResult<T>> AsResultAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            T? data = response.StatusCode == HttpStatusCode.NoContent
                ? default
                : await response.Content.ReadFromJsonAsync<T>();

            return await WrapperResult<T>.SuccessAsync(data ?? default!);
        }
            
        string jsonResponseStr = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (string.IsNullOrEmpty(jsonResponseStr))
            return await WrapperResult<T>.FailAsync(new ErrorModel()
            {
                Message = "Response content was null unexpectedly"
            });

        var apiErrors = JsonSerializer.Deserialize<List<ErrorModel>>(jsonResponseStr);
        if (apiErrors != null)
        {
            return await WrapperResult<T>.FailAsync(apiErrors.Select(apiErr => new ErrorModel { Message = apiErr.Message }).ToList());
        }
            
        return await WrapperResult<T>.FailAsync(new ErrorModel()
        {
            Message = "Error parsing response"
        });
    }

    public static HttpStatusCode? GetApiStatusCode<T>(this FluentResults.Result<T> result)
    {
        foreach (var error in result.Errors)
        {
            if (error.Metadata.ContainsKey(ApiStatusCode)
                && error.Metadata[ApiStatusCode] is HttpStatusCode statusCode)
            {
                return statusCode;
            }
        }

        return null;
    }
    
    public static IEnumerable<ErrorModel> GetApiErrors<T>(this FluentResults.Result<T> result) =>
        result.Errors.Aggregate(new List<ErrorModel>(), (list, error) =>
        {
            if (error.Metadata.ContainsKey(ApiErrorKey)
                && error.Metadata[ApiErrorKey] is ErrorModel apiError)
            {
                list.Add(apiError);
            }

            return list;
        });
    
    public static async Task<WrapperResult<TModel>> ToServiceResultAsync<TResponse, TModel>(this Task<WrapperResult<TResponse>> taskResult)
    {
        var result = await taskResult.ConfigureAwait(false);
        if (result.Errors != null)
            return result.Succeeded
                ? await WrapperResult<TModel>.SuccessAsync(result.Data.Adapt<TModel>())
                : await WrapperResult<TModel>.FailAsync(result.Errors);
        return new WrapperResult<TModel>();
    }
}
