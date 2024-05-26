namespace WebApp.Application.Common.Constants;

public struct DefaultWebApiConst
{
    private const string ApiVer_1 = "v1.0";
    private const string BaseApiVer_1_Segment = $"api/{ApiVer_1}";

    public struct ApplicationParameters
    {
        private const string Base = "application-parameters";

        public const string GetAllConfigs = $"{BaseApiVer_1_Segment}/{ApplicationParameters.Base}";
    }
}
