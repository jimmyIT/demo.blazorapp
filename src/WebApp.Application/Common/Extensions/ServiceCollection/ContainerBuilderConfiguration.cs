using Autofac;
using Autofac.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
namespace WebApp.Application.Common.Extensions.ServiceCollection;

public static class ContainerBuilderConfiguration
{
    public static void AddContainerBuilderConfiguration(this IServiceCollection services, IHostBuilder builder)
    {
        builder.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            Type[] types = Assembly.GetAssembly(typeof(BaitedService))!.GetLoadableTypes()
                .Where(x =>
                {
                    bool result = x is { Namespace: not null, IsClass: true, IsAbstract: false }
                                  && !x.IsSubclassOf(typeof(Delegate))
                                  && x.GetInterfaces()?.Any() is true
                                  && (x.Namespace!.StartsWith("WebApp.Application.Processors")
                                      || x.Namespace.StartsWith("WebApp.Application.Service"));
                    return result;
                }).ToArray();

            containerBuilder.RegisterTypes(types).AsImplementedInterfaces();
        });
    }
}
