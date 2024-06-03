using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Handlers;
using Source.Server.Application.Handlers.WeatherForeCast.Get;
using Source.Server.Application.Services.Internal.Errors.GetByCode;

namespace Source.Server.Application.Wrappers.WeatherForeCast;

public interface IWeatherForeCastHandlerWrapper
    : IBaseHandler
{
    IGetWeatherForeCastHandler GetWeatherForeCast { get; }
}

public class WeatherForeCastHandlerWrapper(
        ILogger<BaseHandler> logger,
        IApplicationRepositories repos,
        IGetWeatherForeCastHandler getWeatherForeCastHandler,
        IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IWeatherForeCastHandlerWrapper
{
    private IGetWeatherForeCastHandler _getWeatherForeCastHandler = getWeatherForeCastHandler;

    public IGetWeatherForeCastHandler GetWeatherForeCast => _getWeatherForeCastHandler;
}