using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Source.Shared.Models;
using System.Text;

namespace Source.Shared.Extensions.ServiceCollectionBuilder.APICollection;

public static class AuthenticationConfiguration
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        JwtOptions? jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();

        if (jwtOptions is null)
        {
            throw new ArgumentNullException(nameof(jwtOptions));
        }

        services.AddSingleton(jwtOptions);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    // Convert the string signing key to byte array
                    byte[] signingKeyBytes = Encoding.UTF8
                        .GetBytes(jwtOptions.SigningKey);

                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });
    }

    public static void UseAuthenticationConfiguration(this IApplicationBuilder app)
    {
        // 👇 This add the Authentication Middleware
        app.UseAuthentication();

        // 👇 This add the Authorization Middleware
        app.UseAuthorization();
    }
}
