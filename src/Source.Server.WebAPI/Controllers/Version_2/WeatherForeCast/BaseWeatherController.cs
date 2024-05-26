using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Wrappers.WeatherForeCast;
using Source.Shared.Common.ApiConstants;

namespace Source.Server.WebAPI.Controllers.Version_2.WeatherForeCast;

/// <summary>
/// base weather forecast ver2
/// </summary>
/// <param name="logger"></param>
/// <param name="weatherForeCastHandlerWrapper"></param>
[Route($"{ApiRouteConst.Default}/{ApiRouteConst.Controllers.WeatherForecast}")]
[ApiExplorerSettings(GroupName = ApiRouteConst.Groups.WeatherForecast)]
public class BaseWeatherController(
        ILogger<BaseWeatherController> logger,
        IWeatherForeCastHandlerWrapper weatherForeCastHandlerWrapper)
    : Ver2_BaseController(logger)
{
    /// <summary>
    /// wrapper.
    /// </summary>
    protected readonly IWeatherForeCastHandlerWrapper _weatherForeCastHandlerWrapper = weatherForeCastHandlerWrapper;
}
