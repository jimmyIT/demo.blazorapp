using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Students;
using Source.Server.Application.Handlers.Students.Create;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.Students.Create;

[ApiVersion(ApiRouteConst.Version.V1_0)]
public class CreateStudentController
    : BaseStudentController
{
    public CreateStudentController(
        ILogger<Ver1_BaseController> logger,
        IStudentHandlerWrapper studentHandlerWrapper)
        : base(logger, studentHandlerWrapper)
    {
    }

    [HttpPost]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.StudentAction.Create)]
    public async Task<ActionResult<CreateStudentResponse>> CreateAsync(CreateStudentRequest request)
        => await DoActionAsync(() => _studentHandlerWrapper.Create.DoActionAsync(request), HttpStatusCode.OK);
}
