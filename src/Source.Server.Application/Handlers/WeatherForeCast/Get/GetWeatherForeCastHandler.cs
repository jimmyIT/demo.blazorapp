using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services.Errors.GetByCode;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.WeatherForeCast.Get;
public interface IGetWeatherForeCastHandler
    : IBaseHandler
{
    Task<WrapperResult<IEnumerable<GetWeatherForecastResponse>>> DoActionAsync();
}

public class GetWeatherForeCastHandler(
        ILogger<BaseHandler> logger,
        IApplicationRepositories repos,
        IGetErrorByCodeService getErrorByCodeService)
    : BaseHandler(logger, repos, getErrorByCodeService), IGetWeatherForeCastHandler
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WrapperResult<IEnumerable<GetWeatherForecastResponse>>> DoActionAsync()
        => await WrapperResult<IEnumerable<GetWeatherForecastResponse>>.SuccessAsync(
            Enumerable.Range(1, 5)
                      .Select(index => new GetWeatherForecastResponse
                      {
                          Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                          TemperatureC = Random.Shared.Next(-20, 55),
                          Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                      })
                      .ToArray());
}
