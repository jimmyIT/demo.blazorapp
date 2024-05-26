using Mapster;
using Microsoft.Extensions.Logging;
using Source.EF.Entities.School;
using Source.EF.Repositories.School;
using Source.Server.Application.Handlers.Students.GetAll;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.Students.GetByCode;
public interface IGetStudentByCodeHandler
    : IBaseHandler
{
    Task<WrapperResult<GetStudentByCodeResponse>> DoActionAsync(string code);
}

public class GetStudentByCodeHandler
    : BaseHandler, IGetStudentByCodeHandler
{
    private readonly ISchoolRepository _schoolRepo;
    public GetStudentByCodeHandler(
        ILogger<BaseHandler> logger,
        ISchoolRepository schoolRepository)
        : base(logger)
    {
        _schoolRepo = schoolRepository;
    }

    public async Task<WrapperResult<GetStudentByCodeResponse>> DoActionAsync(string code)
    {
        Student? student = await _schoolRepo.Student.GetByCodeAsync(code);
        
        if (student is null)
        {
            return await WrapperResult<GetStudentByCodeResponse>
                .FailAsync(new ErrorModel()
                {
                    Message = $"{code} does not exist."
                });
        }

        GetStudentByCodeResponse response = student.Adapt<GetStudentByCodeResponse>();

        return await WrapperResult<GetStudentByCodeResponse>
            .SuccessAsync(response);
    }
}
