using Source.Shared.Wrapper;
using System.Security.Claims;

namespace Source.Server.Application.Services.Internal.Token.GetPrincipalFromExpiredToken;

public interface IGetPrincipalFromExpiredTokenService : IBaseService
{
    Task<WrapperResult<ClaimsPrincipal>> DoActionAsync(string token);
}
