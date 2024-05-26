using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class SerilogConfiguration
{
    public static void RegisterSerilogConfiguration(this IHostBuilder builder)
    {
        builder.UseSerilog((context, config) =>
        {
            config
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Source", AppDomain.CurrentDomain.FriendlyName)
                .Enrich.WithProperty("MachineName", Environment.MachineName)
                //Error Log
                .WriteTo.Logger(le => le.Filter.ByIncludingOnly(e => e.Level != LogEventLevel.Information)
                    .WriteTo.File(path: @"logs\Error_.log", rollingInterval: RollingInterval.Day,
                        outputTemplate:
                        "Timestamp: {Timestamp:u} MachineName: {MachineName} MachineTime: {Timestamp:yyyy-MM-dd HH:mm:ss.fff} Source: {Source} Status: {Level} Message: {Message} MessageDetail: {Exception}{NewLine}{NewLine}"))
                //Event log
                .WriteTo.Logger(le => le.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
                    .WriteTo.File(path: @"logs\Event_.log", rollingInterval: RollingInterval.Day,
                        outputTemplate: "Timestamp: {Timestamp:u} MachineName: {MachineName} MachineTime: {Timestamp:yyyy-MM-dd HH:mm:ss.fff} Source: {Source} Status: {Level} Message: {Message} MessageDetail:{NewLine}{NewLine}"));

            if (context.HostingEnvironment.IsDevelopment())
            {
                config.WriteTo.Console(
                    LogEventLevel.Debug,
                    outputTemplate: "Timestamp: {Timestamp:u} MachineName: {MachineName} MachineTime: {Timestamp:yyyy-MM-dd HH:mm:ss.fff} Source: {Source} Status: {Level} Message: {Message} MessageDetail: {Exception}{NewLine}{NewLine}");
            }
        });
    }
}
