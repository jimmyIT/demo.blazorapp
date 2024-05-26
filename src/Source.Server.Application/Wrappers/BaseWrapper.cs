using Microsoft.Extensions.Logging;

namespace Source.Server.Application.Wrappers;

public interface IBaseWrapper
{
}

public class BaseWrapper(ILogger<BaseWrapper> logger) : IBaseWrapper
{
    protected readonly ILogger<BaseWrapper> _logger = logger;
}