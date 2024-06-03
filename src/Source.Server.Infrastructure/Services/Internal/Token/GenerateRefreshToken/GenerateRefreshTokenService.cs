using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Internal.Token.GenerateRefreshToken;
using Source.Shared.Wrapper;
using System.Security.Cryptography;

namespace Source.Server.Infrastructure.Services.Internal.Token.GenerateRefreshToken;

public class GenerateRefreshTokenService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGenerateRefreshTokenService
{
    public async Task<WrapperResult<string>> DoActionAsync(string identityUserCode)
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return await WrapperResult<string>
                .SuccessAsync(Convert.ToBase64String(randomNumber));
        }
    }
}
