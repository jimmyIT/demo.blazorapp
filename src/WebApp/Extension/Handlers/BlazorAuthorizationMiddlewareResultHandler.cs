using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace WebApp.Extension.Handlers;

public class BlazorAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler handler = new();
    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        // If the authorization was forbidden and the resource had a specific requirement,
        // provide a custom 404 response.
        if (authorizeResult.Forbidden
            && authorizeResult.AuthorizationFailure!.FailedRequirements
                .OfType<Show404Requirement>().Any())
        {
            // Return a 404 to make it appear as if the resource doesn't exist.
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        if (IsFrameworkPath(context.Request.Path) && authorizeResult.Challenged)
        {
            // allow required framework paths to be accessible anonymously
            await handler.HandleAsync(next, context, policy, PolicyAuthorizationResult.Success());
            return;
        }

        await handler.HandleAsync(next, context, policy, authorizeResult);
    }

    private bool IsFrameworkPath(string path)
    {
        return path.StartsWith("/_framework");
    }
}

public class Show404Requirement : IAuthorizationRequirement { }
