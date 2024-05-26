using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.UserProfiles.GetByCode;
using Source.Server.Application.Wrappers.UserProfiles;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.UserProfiles.GetByCode;

/// <summary>
/// Get User Profiles By Code Controller.
/// </summary>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GetUserProfilesByCodeController(
    ILogger<Ver1_BaseController> logger,
    IUserProfilesWrapper userProfilesWrapper)
    : BaseUserProfilesController(logger, userProfilesWrapper)
{
    /// <summary>
    /// Get User Profiles By Code.
    /// </summary>
    /// <param name="code">the user code.</param>
    /// <returns>response obj</returns>
    [HttpGet]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.UserProfiles.GetByCode)]
    public async Task<ActionResult<GetUserProfileByCodeResponse>> GetByCodeAsync([FromRoute] string code)
        => await DoActionAsync(() => _userProfilesWrapper.GetByCodeHandler.DoActionAsync(code), HttpStatusCode.OK);
}
