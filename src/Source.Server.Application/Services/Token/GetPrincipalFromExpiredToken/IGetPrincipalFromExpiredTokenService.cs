using Source.Server.Application.Services;
using Source.Shared.Wrapper;
using System.Security.Claims;

namespace Source.Server.Application.Services.Token.GetPrincipalFromExpiredToken;

public interface IGetPrincipalFromExpiredTokenService : IBaseService
{
    Task<WrapperResult<ClaimsPrincipal>> DoActionAsync(string token);
}
