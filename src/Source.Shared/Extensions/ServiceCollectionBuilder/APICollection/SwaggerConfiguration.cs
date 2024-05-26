using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Source.Shared.Common.ApiConstants;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
            options.TagActionsBy(api =>
            {
                if (api.GroupName != null)
                {
                    return new[] { api.GroupName };
                }
                if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    return new[] { controllerActionDescriptor.ControllerName };
                }
                throw new InvalidOperationException("Unable to determine tag for endpoint.");
            });

            options.DocInclusionPredicate((name, api) => true);

            options.SwaggerDoc($"v{ApiRouteConst.Version.V1_0}", new OpenApiInfo
            {
                Version = $"v{ApiRouteConst.Version.V1_0}",
                Title = $"Code Api {ApiRouteConst.Version.V1_0}",
                Description = "Code Management API",
                TermsOfService = new Uri("https://pragimtech.com"),
                Contact = new OpenApiContact
                {
                    Name = "Jimmy Voz",
                    Email = "phuong.vt5614@gmail.com",
                    Url = new Uri("https://twitter.com/"),
                },
                License = new OpenApiLicense
                {
                    Name = "Jimm Voz Open License",
                    Url = new Uri("https://pragimtech.com"),
                }
            });

            options.SwaggerDoc($"v{ApiRouteConst.Version.V2_0}", new OpenApiInfo
            {
                Version = $"v{ApiRouteConst.Version.V2_0}",
                Title = $"Code Api {ApiRouteConst.Version.V2_0}",
                Description = "Code Management API",
                TermsOfService = new Uri("https://pragimtech.com"),
                Contact = new OpenApiContact
                {
                    Name = "Jimmy Voz",
                    Email = "phuong.vt5614@gmail.com",
                    Url = new Uri("https://twitter.com/"),
                },
                License = new OpenApiLicense
                {
                    Name = "Jimm Voz Open License",
                    Url = new Uri("https://pragimtech.com"),
                }
            });

            options.DocInclusionPredicate((docName, apiDesc) =>
            {
                if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                var versions = methodInfo.DeclaringType?.GetCustomAttributes(true)
                                                        .OfType<ApiVersionAttribute>()
                                                        .SelectMany(attr => attr.Versions);

                return versions?.Any(v => $"v{v.ToString()}" == docName) ?? false;
            });
        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app, bool isDevelopment)
    {
        // Configure the HTTP request pipeline.
        if (isDevelopment)
        {
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
                options.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.ConfigObject.AdditionalItems.Add("tagsSorter", "alpha");

                options.SwaggerEndpoint($"/swagger/v{ApiRouteConst.Version.V1_0}/swagger.json", $"Api Version {ApiRouteConst.Version.V1_0}");
                options.SwaggerEndpoint($"/swagger/v{ApiRouteConst.Version.V2_0}/swagger.json", $"Api Version {ApiRouteConst.Version.V2_0}");
            });
        }
    }
}
