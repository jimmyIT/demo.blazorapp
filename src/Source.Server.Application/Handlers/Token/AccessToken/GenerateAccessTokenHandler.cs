using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Internal.Errors.GetByCode;
using Source.Server.Application.Services.Internal.Token.GenerateAccessToken;
using Source.Server.Application.Services.Internal.Token.GenerateRefreshToken;
using Source.Shared.Models;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.Token.AccessToken;

public interface IGenerateAccessTokenHandler
    : IBaseHandler
{
    Task<WrapperResult<GenerateAccessTokenResponse>> DoActionAsync(GenerateAccessTokenRequest request);
}

public class GenerateAccessTokenHandler(
        ILogger<BaseHandler> logger,
        IApplicationRepositories repos,
        JwtOptions jwtOptions,
        IGenerateAccessTokenService generateAccessTokenService,
        IGenerateRefreshTokenService generateRefreshTokenService,
        IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IGenerateAccessTokenHandler
{
    private readonly JwtOptions _jwtOptions = jwtOptions;
    private readonly IGenerateAccessTokenService _generateAccessTokenService = generateAccessTokenService;
    private readonly IGenerateRefreshTokenService _generateRefreshTokenService = generateRefreshTokenService;
    
    public async Task<WrapperResult<GenerateAccessTokenResponse>> DoActionAsync(GenerateAccessTokenRequest request)
    {
        // TODO: Validate Request

        TimeSpan tokenExpiration = TimeSpan.FromSeconds(_jwtOptions.ExpirationSeconds);
        string identityUserCode = string.Empty;

        WrapperResult<string> rawAccessTokenResult =
            await _generateAccessTokenService.DoActionAsync(
                new GenerateAccessTokenModel(request.UserName, identityUserCode, _jwtOptions));

        WrapperResult<string> refreshTokenResult =
            await _generateRefreshTokenService.DoActionAsync(identityUserCode);

        return await WrapperResult<GenerateAccessTokenResponse>.SuccessAsync(
            new GenerateAccessTokenResponse()
            {
                AccessToken = rawAccessTokenResult.Data,
                RefreshToken = refreshTokenResult.Data,
                Expiration = (int)tokenExpiration.TotalSeconds,
                Type = "Bearer"
            });
    }
}
