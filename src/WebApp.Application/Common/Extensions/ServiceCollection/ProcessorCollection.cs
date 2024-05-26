using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Processors.Identity.SignIn;

namespace WebApp.Application.Common.Extensions.ServiceCollection;

public static class ProcessorCollection
{
    public static void AddScopedProcessors(this IServiceCollection services)
    {
        services.AddScoped<ISignInProcessor, SignInProcessor>();
    }
}
