using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Server.Application.Services.Token.GenerateAccessToken;
using Source.Server.Application.Services.Token.GetPrincipalFromExpiredToken;
using Source.Shared.Models;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.Token.RefreshToken;
public interface IRefreshTokenHandler : IBaseHandler
{
    Task<WrapperResult<RefreshTokenResponse>> DoActionAsync(RefreshTokenRequest request);
}

public class RefreshTokenHandler(
        ILogger<BaseHandler> logger,
        IApplicationRepositories repos,
        JwtOptions jwtOptions,
        IGenerateAccessTokenService generateTokenService,
        IGetPrincipalFromExpiredTokenService getPrincipalFromExpiredTokenService,
        IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IRefreshTokenHandler
{
    private readonly JwtOptions _jwtOptions = jwtOptions;
    private readonly IGenerateAccessTokenService _generateTokenService = generateTokenService;
    private readonly IGetPrincipalFromExpiredTokenService _getPrincipalFromExpiredTokenService = getPrincipalFromExpiredTokenService;

    public Task<WrapperResult<RefreshTokenResponse>> DoActionAsync(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }
}
