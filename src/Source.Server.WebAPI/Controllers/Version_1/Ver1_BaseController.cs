namespace Source.Server.WebAPI.Controllers.Version_1;

/// <summary>
/// base ver1 controller
/// </summary>
/// <param name="logger"></param>
public class Ver1_BaseController(
        ILogger<Ver1_BaseController> logger)
    : BaseController(logger)
{
}
