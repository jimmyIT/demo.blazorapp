using Azure;
using Mapster;
using Microsoft.Extensions.Logging;
using Source.EF.Entities.School;
using Source.EF.Repositories.School;
using Source.Server.Application.Handlers.Students.GetByCode;
using Source.Shared.Wrapper;
using System.Collections.Generic;

namespace Source.Server.Application.Handlers.Students.GetAll;

public interface IGetAllStudentsHandler
    : IBaseHandler
{
    Task<WrapperResult<IEnumerable<GetAllStudentsResponse>>> DoActionAsync();
}

public class GetAllStudentsHandler
    : BaseHandler, IGetAllStudentsHandler
{
    private readonly ISchoolRepository _schoolRepo;
    public GetAllStudentsHandler(
        ILogger<BaseHandler> logger,
        ISchoolRepository schoolRepository)
        : base(logger)
    {
        _schoolRepo = schoolRepository;
    }

    public async Task<WrapperResult<IEnumerable<GetAllStudentsResponse>>> DoActionAsync()
    {
        IEnumerable<Student> students = await _schoolRepo.Student.GetAllAsync();

        IEnumerable<GetAllStudentsResponse> response =
            students.Adapt<IEnumerable<GetAllStudentsResponse>>();

        return await WrapperResult<IEnumerable<GetAllStudentsResponse>>
            .SuccessAsync(response);
    }
}
