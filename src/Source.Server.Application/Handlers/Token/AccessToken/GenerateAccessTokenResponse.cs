namespace Source.Server.Application.Handlers.Token.AccessToken;

public record GenerateAccessTokenResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Expiration { get; set; }
}
