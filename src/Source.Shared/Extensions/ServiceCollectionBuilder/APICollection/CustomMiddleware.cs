using Microsoft.AspNetCore.Builder;
using Source.Shared.Extensions.Middlewares;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class CustomMiddleware
{
    public static void UseCustomMiddlewaresForApi(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExampleCustomMiddleware>();
    }
}
