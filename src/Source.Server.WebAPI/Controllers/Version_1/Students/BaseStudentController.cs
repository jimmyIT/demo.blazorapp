using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Students;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_1.Students;

[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.Student}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.Student)]
public class BaseStudentController : Ver1_BaseController
{
    protected readonly IStudentHandlerWrapper _studentHandlerWrapper;

    public BaseStudentController(
        ILogger<Ver1_BaseController> logger,
        IStudentHandlerWrapper studentHandlerWrapper)
        : base(logger)
    {
        _studentHandlerWrapper = studentHandlerWrapper;
    }
}
