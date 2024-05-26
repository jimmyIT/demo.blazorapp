using Source.Shared.Wrapper;
using WebApp.Application.Service.Interfaces.ApplicationParameters.GetAllConfigs;

namespace WebApp.Application.Processors.ApplicationParameters.GetAll;

public interface IGetApplicationConfigurationProcessor
{
    Task<WrapperResult<GetApplicationConfigurationModel>> DoActionAsync();
}

public class GetApplicationConfigurationProcessor
    (IGetAllConfigsService getAllConfigsService)
    : IGetApplicationConfigurationProcessor
{
    private readonly IGetAllConfigsService _getAllConfigsService = getAllConfigsService;

    public async Task<WrapperResult<GetApplicationConfigurationModel>> DoActionAsync()
    {
        WrapperResult<GetAllConfigsServiceResult> svcResult = await _getAllConfigsService.DoActionAsync();

        return await WrapperResult<GetApplicationConfigurationModel>.SuccessAsync();
    }
}
