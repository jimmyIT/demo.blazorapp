using Microsoft.Extensions.Logging;
using Source.EF.Entities.Error;
using Source.EF.Repositories;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Infrastructure.Services.Errors.GetByCode;

public class GetErrorByCodeService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGetErrorByCodeService
{
    public async Task<WrapperResult<ErrorModel>> GetByKeyAsync(string errorCode)
    {
        ErrorEntity? errorEntity = await _repos.Error.GetByCodeAsync(errorCode);

        if (errorEntity == null)
        {
            return await WrapperResult<ErrorModel>.FailAsync(new ErrorModel()
            {
                Code = string.Empty,
                Message = $"Does not exist the error entity by {errorCode}."
            });
        }

        return await WrapperResult<ErrorModel>.SuccessAsync(
            new ErrorModel()
            {
                Code = errorEntity.Code,
                Message = errorEntity.ErrorMessage
            });
    }
}
