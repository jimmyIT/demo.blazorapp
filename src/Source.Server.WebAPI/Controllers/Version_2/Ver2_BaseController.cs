using Microsoft.AspNetCore.Mvc;

namespace Source.Server.WebAPI.Controllers.Version_2;

/// <summary>
/// base ver2 controller.
/// </summary>
/// <param name="logger"></param>
[ApiController]
public class Ver2_BaseController(
        ILogger<Ver2_BaseController> logger)
    : BaseController(logger)
{
}
