using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Polly;
using Source.Shared.Wrapper;
using System.Net;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace Source.Server.WebAPI.Controllers;

/// <summary>
/// Base Controller.
/// </summary>
[ApiController]
public class BaseController
    (ILogger<BaseController> logger)
    : Controller
{
    /// <summary>
    /// Logger.
    /// </summary>
    protected readonly ILogger<BaseController> _logger = logger;

    internal async Task<ActionResult<T>> DoActionAsync<T>(
        Func<Task<WrapperResult<T>>> func,
        HttpStatusCode successStatusCode)
    {
        WrapperResult<T> response = await Policy
                .Handle<SqlException>()
                .WaitAndRetryAsync(3, retryAttemp => TimeSpan.FromSeconds(5))
                .ExecuteAsync(async () =>
                {
                    return await func();
                });

        if (response.Succeeded is false)
        {
            return BadRequest400Async(response.Errors);
        }

        return successStatusCode switch
        {
            HttpStatusCode.OK => Ok200Async(response.Data),
            HttpStatusCode.Created => Created201Async(response.Data),
            HttpStatusCode.NoContent => NoContent204Async(),
            _ => NoContent204Async()
        };
    }

    ActionResult Ok200Async(object? response) => Ok(response);
    ActionResult BadRequest400Async(object? response) => BadRequest(response);
    ActionResult Created201Async(object? response) => StatusCode((int)HttpStatusCode.Created, response);
    ActionResult NoContent204Async() => NoContent();
}
