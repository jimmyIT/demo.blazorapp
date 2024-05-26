using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Errors.GetByCode;

public interface IGetErrorByCodeService : IBaseService
{
    Task<WrapperResult<ErrorModel>> GetByKeyAsync(string errorCode);
}
