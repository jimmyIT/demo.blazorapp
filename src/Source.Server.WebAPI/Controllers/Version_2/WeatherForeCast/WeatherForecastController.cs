using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Source.Server.Application.Handlers.WeatherForeCast.Get;
using Source.Server.Application.Wrappers.WeatherForeCast;
using Source.Shared.Common.ApiConstants;
using Source.Shared.Wrapper;

namespace Source.Server.WebAPI.Controllers.Version_2.WeatherForeCast;

/// <summary>
/// weather fore cast controller.
/// </summary>
/// <param name="logger"></param>
/// <param name="weatherForeCastHandlerWrapper"></param>
[ApiVersion(ApiRouteConst.Version.V2_0)]
public class WeatherForecastController(
        ILogger<BaseWeatherController> logger,
        IWeatherForeCastHandlerWrapper weatherForeCastHandlerWrapper)
    : BaseWeatherController(logger, weatherForeCastHandlerWrapper)
{
    /// <summary>
    /// Get weather fore cast.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [MapToApiVersion(ApiRouteConst.Version.V2_0)]
    [Route(ApiRouteConst.Actions.WeatherForecastAction.Get)]
    public async Task<WrapperResult<IEnumerable<GetWeatherForecastResponse>>> GetAsync()
        => await _weatherForeCastHandlerWrapper.GetWeatherForeCast.DoActionAsync();
}
