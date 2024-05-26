using Microsoft.Extensions.DependencyInjection;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class CORSConfiguration
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
}
