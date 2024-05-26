using Flurl.Http.Configuration;
using Mapster;
using Microsoft.Extensions.Options;
using Source.Shared.Models;
using Source.Shared.Wrapper;
using WebApp.Application.Common.Constants;
using WebApp.Application.Service.Interfaces.ApplicationParameters.GetAllConfigs;

namespace WebApp.Application.Service.Backends.DefaultWebApi.ApplicationParameters.GetAllConfigs;

public class GetAllConfigsService(
    IOptions<WebApiSettings> apiConfigurationOption,
    IFlurlClientCache flurlClientCache)
    : BaseDefaultWebApiService(apiConfigurationOption, flurlClientCache), IGetAllConfigsService
{
    public async Task<WrapperResult<GetAllConfigsServiceResult>> DoActionAsync()
    {
        string url = DefaultWebApiConst.ApplicationParameters.GetAllConfigs;

        WrapperResult<GetApplicationParametersApiResponse> apiWrapperResult =
            await GetAsync<GetApplicationParametersApiResponse>(url);

        if (apiWrapperResult.Succeeded is false)
        {
            return await WrapperResult<GetAllConfigsServiceResult>.FailAsync(apiWrapperResult.Errors!);
        }

        GetAllConfigsServiceResult getResult = apiWrapperResult.Data.Adapt<GetAllConfigsServiceResult>();

        return await WrapperResult<GetAllConfigsServiceResult>.SuccessAsync(getResult);
    }
}
