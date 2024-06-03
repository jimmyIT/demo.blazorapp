using Microsoft.Extensions.Logging;
using Source.EF.Entities.Parameters;
using Source.EF.Repositories;
using Source.Shared.Wrapper;
using Source.Shared.Common.Helpers;
using Source.Server.Application.Services.Internal.ApplicationParameters.GetValueByKey;

namespace Source.Server.Infrastructure.Services.Internal.ApplicationParameters.GetValueByKey;

public class GetParameterValueByKeyService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGetParameterValueByKeyService
{
    public async Task<WrapperResult<TEnum>> GetValueAsEnumAsync<TEnum>(string paramKey)
        where TEnum : struct, Enum
    {
        ApplicationParameterEntity? paramEntity =
            await _repos.ApplicationParameter.GetByCodeAsync(paramKey);

        if (paramEntity == null)
        {
            return await WrapperResult<TEnum>.FailAsync(new ErrorModel()
            {
                Code = string.Empty,
                Message = $"Does not exist the parameter entity by {paramKey}."
            });
        }

        object paramValue = EnumHelper.ConvertStringToEnum<TEnum>(paramEntity.Value);

        return await WrapperResult<TEnum>.SuccessAsync((TEnum)Convert.ChangeType(paramValue, typeof(TEnum)));
    }

    public async Task<WrapperResult<T>> GetValueAsync<T>(string paramKey)
    {
        ApplicationParameterEntity? paramEntity =
            await _repos.ApplicationParameter.GetByCodeAsync(paramKey);

        if (paramEntity == null)
        {
            return await WrapperResult<T>.FailAsync(new ErrorModel()
            {
                Code = string.Empty,
                Message = $"Does not exist the parameter entity by {paramKey}."
            });
        }

        object paramValue = typeof(T).Name switch
        {
            _ => paramEntity.Value
        };

        return await WrapperResult<T>.SuccessAsync((T)Convert.ChangeType(paramValue, typeof(T)));
    }
}
