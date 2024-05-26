using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.Token;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_1.Token;

/// <summary>
/// Base controller.
/// </summary>
[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.Token}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.Token)]
public class BaseTokenController(
        ILogger<Ver1_BaseController> logger,
        ITokenHandlerWrapper tokenHandlerWrapper)
    : Ver1_BaseController(logger)
{
    /// <summary>
    /// Token handlers wrapper.
    /// </summary>
    protected readonly ITokenHandlerWrapper _tokenHandlerWrapper = tokenHandlerWrapper;
}
