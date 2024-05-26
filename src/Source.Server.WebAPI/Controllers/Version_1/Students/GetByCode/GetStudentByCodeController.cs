using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.Students;
using Source.Server.Application.Handlers.Students.GetByCode;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.Students.GetByCode;

[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GetStudentByCodeController
    : BaseStudentController
{
    public GetStudentByCodeController(
        ILogger<Ver1_BaseController> logger,
        IStudentHandlerWrapper studentHandlerWrapper)
        : base(logger, studentHandlerWrapper)
    {
    }

    [HttpGet]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.StudentAction.GetByCode)]
    public async Task<ActionResult<GetStudentByCodeResponse>> GetAsync([FromRoute] string code)
        => await DoActionAsync(() => _studentHandlerWrapper.GetByCode.DoActionAsync(code), HttpStatusCode.OK);
}
