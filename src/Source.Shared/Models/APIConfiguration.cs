namespace Source.Shared.Models;

public class APIConfiguration
{
    public const string SettingKey = "ApiUrl";
    public WebApiSettings? ApiUrl { get; set; }
}