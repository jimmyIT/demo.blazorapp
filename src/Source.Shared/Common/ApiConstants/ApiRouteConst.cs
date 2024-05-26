using Microsoft.AspNetCore.Http;

namespace Source.Shared.Common.ApiConstants;

public struct ApiRouteConst
{
    public const string Api_Version = "v{version:apiVersion}";
    public const string Default = $"api/{Api_Version}";
    public struct Version
    {
        public const string V1_0 = "1.0";
        public const string V2_0 = "2.0";
    }

    public struct Controllers
    {
        public const string WeatherForecast = "weather-forecast";
        public const string UserProfiles = "user-profiles";
        public const string Token = "token";
        public const string ApplicationParameters = "application-parameters";
    }

    public struct Groups
    {
        public const string WeatherForecast = "Weather Forecast";
        public const string UserProfiles = "User Profiles";
        public const string Token = "Token";
        public const string ApplicationParameters = "Application Parameters";
    }

    public struct Actions
    {
        public struct Token
        {
            public const string AccessToken = "generate-access-token";
            public const string RefreshToken = "refresh-token";
        }

        public struct UserProfiles
        {
            public const string GetByCode = "{code}";
            public const string Create = "";
            public const string GenerateUserProfileCode = "generate-user-code";
        }

        public struct WeatherForecastAction
        {
            public const string Get = "";
        }

        public struct ApplicationParameters
        {
            public const string GetAll = "";
        }

        public struct StudentAction
        {
            public const string GetAll = "";
            public const string GetByCode = "{code}/code";
            public const string Create = "";
        }
    }

    public struct Routes
    {
        //public struct StudentRoutes
        //{
        //    public const string Default = $"{ApiRouteConst.Controllers.Student}";
        //    public const string GetAll = $"{Default}/";
        //    public const string GetByCode = $"{Default}" + "/{code}/code";
        //    public const string Create = $"{Default}/";
        //}
    }
}
