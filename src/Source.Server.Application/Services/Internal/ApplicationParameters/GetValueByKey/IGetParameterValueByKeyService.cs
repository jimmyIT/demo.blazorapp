using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Internal.ApplicationParameters.GetValueByKey;

public interface IGetParameterValueByKeyService : IBaseService
{
    Task<WrapperResult<T>> GetValueAsync<T>(string paramKey);
    Task<WrapperResult<TEnum>> GetValueAsEnumAsync<TEnum>(string paramKey) where TEnum : struct, Enum;
}
