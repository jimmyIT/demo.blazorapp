using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Token.GenerateRefreshToken;

public interface IGenerateRefreshTokenService
{
    Task<WrapperResult<string>> DoActionAsync(string identityUserCode);
}
