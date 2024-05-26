using Microsoft.Extensions.Logging;
using Source.Server.Application.Handlers.Token.AccessToken;
using Source.Server.Application.Handlers.Token.RefreshToken;

namespace Source.Server.Application.Wrappers.Token;
public interface ITokenHandlerWrapper
    : IBaseWrapper
{
    IGenerateAccessTokenHandler GenerateToken { get; }
    IRefreshTokenHandler RefreshToken { get; }
}

public class TokenHandlerWrapper(
        ILogger<BaseWrapper> logger,
        IGenerateAccessTokenHandler generateTokenHandler,
        IRefreshTokenHandler refreshTokenHandler)
    : BaseWrapper(logger), ITokenHandlerWrapper
{
    private IGenerateAccessTokenHandler _generateTokenHandler = generateTokenHandler;
    private IRefreshTokenHandler _refreshTokenHandler = refreshTokenHandler;

    public IGenerateAccessTokenHandler GenerateToken => _generateTokenHandler;
    public IRefreshTokenHandler RefreshToken => _refreshTokenHandler;
}
