using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Token.AccessToken;
using Source.Server.Application.Wrappers.Token;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.Token.Generate;

/// <summary>
/// Generate access token controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="tokenHandlerWrapper"></param>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GenerateAccessTokenController(
        ILogger<Ver1_BaseController> logger,
        ITokenHandlerWrapper tokenHandlerWrapper)
    : BaseTokenController(logger, tokenHandlerWrapper)
{
    /// <summary>
    /// Generate access token action.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.Token.AccessToken)]
    public async Task<ActionResult<GenerateAccessTokenResponse>> PostAsync([FromBody] GenerateAccessTokenRequest request)
        => await DoActionAsync(() => _tokenHandlerWrapper.GenerateToken.DoActionAsync(request), HttpStatusCode.OK) ;
}
