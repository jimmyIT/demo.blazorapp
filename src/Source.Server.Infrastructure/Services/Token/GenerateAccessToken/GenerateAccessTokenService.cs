using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Source.EF.Repositories;
using Source.Server.Application.Services.Token.GenerateAccessToken;
using Source.Shared.Wrapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Source.Server.Infrastructure.Services.Token.GenerateAccessToken;

public class GenerateAccessTokenService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo)
    : BaseService(logger, repo), IGenerateAccessTokenService
{
    public async Task<WrapperResult<string>> DoActionAsync(GenerateAccessTokenModel generateAccessToken)
    {
        TimeSpan tokenExpiration = TimeSpan.FromSeconds(generateAccessToken.JwtOptions.ExpirationSeconds);
        
        byte[] keyBytes = Encoding.UTF8.GetBytes(generateAccessToken.JwtOptions.SigningKey);
        SymmetricSecurityKey symmetricKey = new(keyBytes);

        SigningCredentials signingCredentials = new(
            symmetricKey,
            // 👇 one of the most popular.
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim("sub", generateAccessToken.IdentityCode),
            new Claim("name", generateAccessToken.UserName),
            new Claim("aud", generateAccessToken.JwtOptions.Audience)
        };

        var permissions = new[] { "read_todo", "create_todo" };
        var roleClaims = permissions.Select(x => new Claim("role", x));

        claims.AddRange(roleClaims);

        var token = new JwtSecurityToken(
            issuer: generateAccessToken.JwtOptions.Issuer,
            audience: generateAccessToken.JwtOptions.Audience,
            claims: claims,
            expires: DateTime.Now.Add(tokenExpiration),
            signingCredentials: signingCredentials);

        return await WrapperResult<string>.SuccessAsync(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
