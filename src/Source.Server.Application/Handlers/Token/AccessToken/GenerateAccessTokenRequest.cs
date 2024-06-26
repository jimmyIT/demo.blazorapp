﻿namespace Source.Server.Application.Handlers.Token.AccessToken;

public record GenerateAccessTokenRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
