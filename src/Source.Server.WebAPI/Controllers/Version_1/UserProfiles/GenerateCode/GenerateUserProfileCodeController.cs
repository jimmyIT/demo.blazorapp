using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.UserProfiles;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.UserProfiles.GenerateCode;

/// <summary>
/// Generate User Profile Code Controller.
/// </summary>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GenerateUserProfileCodeController(
    ILogger<Ver1_BaseController> logger,
    IUserProfilesWrapper userProfilesWrapper)
    : BaseUserProfilesController(logger, userProfilesWrapper)
{
    /// <summary>
    /// Generate User Profile Code.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.UserProfiles.GenerateUserProfileCode)]
    public async Task<ActionResult<string>> PostAsync()
        => await DoActionAsync(() => _userProfilesWrapper.GenerateUserProfileCodeHandler.DoActionAsync(), HttpStatusCode.OK);
}
