using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.ApplicationParameters.GetAll;
using Source.Server.Application.Wrappers.ApplicationParameters;
using Source.Shared.Common.ApiConstants;
using System.Net;

namespace Source.Server.WebAPI.Controllers.Version_1.ApplicationParameters.GetAll;

/// <summary>
/// Get All Configurations Controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="applicationParametersWrapper"></param>
[ApiVersion(ApiRouteConst.Version.V1_0)]
public class GetAllApplicationParametersController(
    ILogger<Ver1_BaseController> logger,
    IApplicationParametersWrapper applicationParametersWrapper)
    : BaseApplicationParametersController(logger, applicationParametersWrapper)
{
    /// <summary>
    /// Get parameters configuration endpoint.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [MapToApiVersion(ApiRouteConst.Version.V1_0)]
    [Route(ApiRouteConst.Actions.ApplicationParameters.GetAll)]
    public async Task<ActionResult<GetAllApplicationParametersResponse>> GetAsync()
        => await DoActionAsync(() => applicationParametersWrapper.GetAllParams.DoActionAsync(), HttpStatusCode.OK);
}
