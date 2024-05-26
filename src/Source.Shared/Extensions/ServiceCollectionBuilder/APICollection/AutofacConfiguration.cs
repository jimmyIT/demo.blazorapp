using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class AutofacConfiguration
{
    public static void AddAutofacConfiguration(this IHostBuilder builder)
    {
        builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterAssemblyTypes(
                    Assembly.Load("Source.Server.Application"),
                    Assembly.Load("Source.Server.Infrastructure"),
                    Assembly.Load("Source.Shared"),
                    Assembly.Load("Source.EF"))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        });
    }
}
