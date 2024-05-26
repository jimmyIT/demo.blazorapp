using Source.Shared.Wrapper;

namespace WebApp.Application.Service.Interfaces.ApplicationParameters.GetAllConfigs;

public interface IGetAllConfigsService : IBaseDefaultWebApiService
{
    Task<WrapperResult<GetAllConfigsServiceResult>> DoActionAsync();
}
