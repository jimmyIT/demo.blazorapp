using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.UserProfiles.Create;
using Source.Server.Application.Wrappers.UserProfiles;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.UserProfiles.Create;

/// <summary>
/// Create User Profiles Controller.
/// </summary>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class CreateUserProfilesController(
    ILogger<Ver1_BaseController> logger,
    IUserProfilesWrapper userProfilesWrapper)
    : BaseUserProfilesController(logger, userProfilesWrapper)
{
    /// <summary>
    /// Create user profiles.
    /// </summary>
    /// <param name="request">user profiles request.</param>
    /// <returns></returns>
    [HttpPost]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.UserProfiles.Create)]
    public async Task<ActionResult<CreateUserProfilesResponse>> CreateAsync([FromBody] CreateUserProfilesRequest request)
        => await DoActionAsync(() => _userProfilesWrapper.CreateHandler.DoActionAsync(request), HttpStatusCode.Created);
}
