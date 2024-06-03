using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Internal.Token.GenerateRefreshToken;

public interface IGenerateRefreshTokenService
{
    Task<WrapperResult<string>> DoActionAsync(string identityUserCode);
}
