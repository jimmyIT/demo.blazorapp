using Microsoft.Extensions.Logging;
using Source.Server.Application.Handlers.ApplicationParameters.GetAll;

namespace Source.Server.Application.Wrappers.ApplicationParameters;

public interface IApplicationParametersWrapper : IBaseWrapper
{
    IGetAllApplicationParametersHandler GetAllParams {  get; }
}

public class ApplicationParametersWrapper(
    ILogger<BaseWrapper> logger,
    IGetAllApplicationParametersHandler getAllApplicationParametersHandler)
    : BaseWrapper(logger), IApplicationParametersWrapper
{
    public IGetAllApplicationParametersHandler GetAllParams => getAllApplicationParametersHandler;
}
