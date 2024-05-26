using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Students;
using Source.Server.Application.Handlers.Students.GetAll;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.Students.GetAll;

[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GetAllStudentsController
    : BaseStudentController
{
    public GetAllStudentsController(
        ILogger<Ver1_BaseController> logger,
        IStudentHandlerWrapper studentHandlerWrapper)
        : base(logger, studentHandlerWrapper)
    {
    }

    [HttpGet]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.StudentAction.GetAll)]
    public async Task<ActionResult<IEnumerable<GetAllStudentsResponse>>> GetAsync()
        => await DoActionAsync(() => _studentHandlerWrapper.GetAll.DoActionAsync(), HttpStatusCode.OK);
}
