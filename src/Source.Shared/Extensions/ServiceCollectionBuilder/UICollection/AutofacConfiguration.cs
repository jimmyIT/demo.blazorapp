using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.UICollection;

public static class AutofacConfiguration
{
    public static void AddAutofacConfiguration(this IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterAssemblyTypes(
                    Assembly.Load("WebApp.Application"),
                    Assembly.Load("Source.Shared"))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        });
    }
}
