using Microsoft.Extensions.DependencyInjection;
using Source.Shared.Extensions.ExceptionHandlers;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class ExceptionConfiguration
{
    public static void AddExeptionConfiguration(this IServiceCollection services)
    {
        services.AddExceptionHandler<TimeOutExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
    }
}
