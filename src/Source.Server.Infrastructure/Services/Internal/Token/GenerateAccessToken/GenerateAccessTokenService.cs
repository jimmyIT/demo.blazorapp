using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Source.EF.Repositories;
using Source.Server.Application.Services.Internal.Token.GenerateAccessToken;
using Source.Shared.Wrapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Source.Server.Infrastructure.Services.Internal.Token.GenerateAccessToken;

public class GenerateAccessTokenService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGenerateAccessTokenService
{
    public async Task<WrapperResult<string>> DoActionAsync(GenerateAccessTokenModel generateAccessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(generateAccessToken.JwtOptions.SigningKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new[] {
                    new Claim("sub", generateAccessToken.IdentityCode),
                    new Claim("name", generateAccessToken.UserName),
                    new Claim("aud", generateAccessToken.JwtOptions.Audience)
                }),
            Expires = DateTime.UtcNow.AddSeconds(generateAccessToken.JwtOptions.ExpirationSeconds), // Token expiration time
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
                
        var claims = new List<Claim>()
        {
            new Claim("sub", generateAccessToken.IdentityCode),
            new Claim("name", generateAccessToken.UserName),
            new Claim("aud", generateAccessToken.JwtOptions.Audience)
        };

        return await WrapperResult<string>.SuccessAsync(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
