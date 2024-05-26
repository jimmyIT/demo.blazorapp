using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Token.RefreshToken;
using Source.Server.Application.Wrappers.Token;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.Token.Refresh;

/// <summary>
/// Refresh token controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="tokenHandlerWrapper"></param>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class RefreshTokenController(
        ILogger<Ver1_BaseController> logger,
        ITokenHandlerWrapper tokenHandlerWrapper)
    : BaseTokenController(logger, tokenHandlerWrapper)
{
    /// <summary>
    /// Re-generate access token.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.Token.RefreshToken)]
    public async Task<ActionResult<RefreshTokenResponse>> PostAsync([FromBody] RefreshTokenRequest request)
        => await DoActionAsync(() => _tokenHandlerWrapper.RefreshToken.DoActionAsync(request), HttpStatusCode.OK);
}
