using Source.Shared.Models;

namespace Source.Server.Application.Services.Token.GenerateAccessToken;

public record class GenerateAccessTokenModel(
    string UserName,
    string IdentityCode,
    JwtOptions JwtOptions);