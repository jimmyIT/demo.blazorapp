using Microsoft.Extensions.Logging;
using Source.Server.Application.Handlers.Students.Create;
using Source.Server.Application.Handlers.Students.GetAll;
using Source.Server.Application.Handlers.Students.GetByCode;

namespace Source.Server.Application.Handlers.Students;

public interface IStudentHandlerWrapper
    : IBaseHandler
{
    IGetAllStudentsHandler GetAll { get; }
    IGetStudentByCodeHandler GetByCode { get; }
    ICreateStudentHandler Create { get; }
}

public class StudentHandlerWrapper
    : BaseHandler, IStudentHandlerWrapper
{
    private IGetAllStudentsHandler _getAllStudentsHandler;
    private IGetStudentByCodeHandler _getByCodeHandler;
    private ICreateStudentHandler _createStudentHandler;
    public StudentHandlerWrapper(
        ILogger<BaseHandler> logger,
        IGetAllStudentsHandler getAllStudentsHandler,
        IGetStudentByCodeHandler getByCodeHandler,
        ICreateStudentHandler createStudentHandler)
        : base(logger)
    {
        _getAllStudentsHandler = getAllStudentsHandler;
        _getByCodeHandler = getByCodeHandler;
        _createStudentHandler = createStudentHandler;
    }

    public IGetAllStudentsHandler GetAll => _getAllStudentsHandler;
    public IGetStudentByCodeHandler GetByCode => _getByCodeHandler;
    public ICreateStudentHandler Create => _createStudentHandler;
}
