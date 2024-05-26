using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.ApplicationParameters;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_1.ApplicationParameters;

/// <summary>
/// Base application parameters controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="applicationParametersWrapper"></param>
[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.ApplicationParameters}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.ApplicationParameters)]
public class BaseApplicationParametersController(
    ILogger<Ver1_BaseController> logger,
    IApplicationParametersWrapper applicationParametersWrapper)
    : Ver1_BaseController(logger)
{
    /// <summary>
    /// Application Parameters Wrapper
    /// </summary>
    protected readonly IApplicationParametersWrapper _applicationParametersWrapper = applicationParametersWrapper;
}
