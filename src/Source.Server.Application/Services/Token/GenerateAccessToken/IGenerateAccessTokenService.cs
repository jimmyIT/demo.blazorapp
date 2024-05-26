﻿using Source.Shared.Wrapper;

namespace Source.Server.Application.Services.Token.GenerateAccessToken;

public interface IGenerateAccessTokenService : IBaseService
{
    Task<WrapperResult<string>> DoActionAsync(GenerateAccessTokenModel generateAccessTokenModel);
}
