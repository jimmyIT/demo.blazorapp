using Microsoft.Extensions.Logging;
using Source.EF.Repositories;
using Source.Server.Application.Services;

namespace Source.Server.Infrastructure.Services;

public class BaseService(
    ILogger<BaseService> logger,
    IApplicationRepositories repo) : IBaseService
{
    protected readonly ILogger<BaseService> _logger = logger;
    protected readonly IApplicationRepositories _repos = repo;
}
