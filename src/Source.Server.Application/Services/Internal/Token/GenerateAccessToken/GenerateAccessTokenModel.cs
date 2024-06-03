using Source.Shared.Models;

namespace Source.Server.Application.Services.Internal.Token.GenerateAccessToken;

public record class GenerateAccessTokenModel(
    string UserName,
    string IdentityCode,
    JwtOptions JwtOptions);