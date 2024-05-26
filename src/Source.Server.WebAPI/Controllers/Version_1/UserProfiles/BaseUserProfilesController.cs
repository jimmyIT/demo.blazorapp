
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.UserProfiles;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_1.UserProfiles;

/// <summary>
/// Base controller.
/// </summary>
[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.UserProfiles}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.UserProfiles)]
public class BaseUserProfilesController(
    ILogger<Ver1_BaseController> logger,
    IUserProfilesWrapper userProfilesWrapper)
    : Ver1_BaseController(logger)
{
    /// <summary>
    /// User profiles wrapper.
    /// </summary>
    protected readonly IUserProfilesWrapper _userProfilesWrapper = userProfilesWrapper;
}
