using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class CustomApiVersioning
{
    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                new HeaderApiVersionReader("x-api-version"),
                                                                new MediaTypeApiVersionReader("x-api-version"));
            options.ReportApiVersions = true;

        })     // Core API Versioning services with support for Minimal APIs
                .AddMvc()               // API version-aware extensions for MVC Core with controllers (not full MVC)
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstitutionFormat = "VVVV"; // Change version in path fron 'v1' to 'v1.0'
                    options.SubstituteApiVersionInUrl = true;
                });      // API version-aware API Explorer extensions
    }
}
