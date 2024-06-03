using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Internal.Errors.GetByCode;

public interface IGetErrorByCodeService : IBaseService
{
    Task<WrapperResult<ErrorModel>> GetByKeyAsync(string errorCode);
}
