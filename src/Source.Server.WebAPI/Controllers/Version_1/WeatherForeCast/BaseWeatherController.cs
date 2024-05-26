using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.WeatherForeCast;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_1.WeatherForeCast;

/// <summary>
/// base weather fore cast controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="weatherForeCastHandlerWrapper"></param>
[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.WeatherForecast}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.WeatherForecast)]
public class BaseWeatherController(
        ILogger<BaseWeatherController> logger,
        IWeatherForeCastHandlerWrapper weatherForeCastHandlerWrapper)
    : Ver1_BaseController(logger)
{
    /// <summary>
    /// wrapper.
    /// </summary>
    protected readonly IWeatherForeCastHandlerWrapper _weatherForeCastHandlerWrapper = weatherForeCastHandlerWrapper;
}
