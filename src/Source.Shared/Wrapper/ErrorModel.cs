using Newtonsoft.Json;

namespace Source.Shared.Wrapper;

public class ErrorModel
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;
    [JsonProperty("additionalInfo")]
    public string AdditionalInfo { get; set; } = string.Empty;
    [JsonProperty("reference")]
    public string Reference { get; set; } = string.Empty;
}
