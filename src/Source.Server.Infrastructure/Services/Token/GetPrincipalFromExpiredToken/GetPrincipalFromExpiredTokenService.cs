using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Source.EF.Repositories;
using Source.Server.Application.Services.Token.GetPrincipalFromExpiredToken;
using Source.Shared.Wrapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Source.Server.Infrastructure.Services.Token.Refresh;

public class GetPrincipalFromExpiredTokenService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGetPrincipalFromExpiredTokenService
{
    public async Task<WrapperResult<ClaimsPrincipal>> DoActionAsync(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true, //you might want to validate the audience and issuer depending on your use case
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")),
            ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        SecurityToken securityToken;

        var principal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null
            || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return await WrapperResult<ClaimsPrincipal>.SuccessAsync(principal);
    }
}
