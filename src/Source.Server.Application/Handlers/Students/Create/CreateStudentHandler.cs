using Microsoft.Extensions.Logging;
using Source.EF.Entities.School;
using Source.EF.Repositories.School;
using Source.Server.Application.Common.Provider;
using Source.Shared.Providers;
using Source.Shared.Wrapper;

namespace Source.Server.Application.Handlers.Students.Create;

public interface ICreateStudentHandler : IBaseHandler
{
    Task<WrapperResult<CreateStudentResponse>> DoActionAsync(CreateStudentRequest request);
}

public class CreateStudentHandler
    : BaseHandler, ICreateStudentHandler
{
    private readonly ICreateStudentValidator _createStudentValidator;
    private readonly ISchoolRepository _schoolRepo;
    private readonly ICodeGeneratorProvider _codeGeneratorProvider;
    private readonly IDateTimeProvider _timeProvider;
    public CreateStudentHandler(
        ILogger<BaseHandler> logger,
        ISchoolRepository schoolRepo,
        ICodeGeneratorProvider codeGeneratorProvider,
        IDateTimeProvider timeProvider,
        ICreateStudentValidator createStudentValidator)
        : base(logger)
    {
        _schoolRepo = schoolRepo;
        _codeGeneratorProvider = codeGeneratorProvider;
        _timeProvider = timeProvider;
        _createStudentValidator = createStudentValidator;
    }

    public async Task<WrapperResult<CreateStudentResponse>> DoActionAsync(CreateStudentRequest request)
    {
        // Validate Request
        IList<ErrorModel>? errors =
            await ValidateRequestAsync(() => _createStudentValidator.DoActionAsync(request));
        if (errors != null && errors.Any())
        {
            return await WrapperResult<CreateStudentResponse>.FailAsync(errors.ToList());
        }

        try
        {
            IEnumerable<Student> students = await _schoolRepo.Student.GetAllAsync();

            DateTime createdOn = _timeProvider.UtcNow();

            string studentCode = await _codeGeneratorProvider.GenerateAsync(students, null);
            string hashedPassword = CryptorEngineProvider.Create_HashSHA1($"{request.Password}{studentCode}");
            Student studentEntity = new()
            {
                Code = studentCode,
                Name = request.Name,
                Weight = request.Weight,
                Height = request.Height,
                DateOfBirth = request.DateOfBirth,
                Photo = request.Photo,
                CreatedOn = createdOn,
                GradeCode = request.GradeCode,
                IdentityUser = new IdentityUser()
                {
                    Name = request.Name,
                    CreatedOn = createdOn,
                    UserName = request.UserName,
                    Password = hashedPassword
                }
            };

            await _schoolRepo.Student.CreateAsync(studentEntity);
            await _schoolRepo.SaveAsync();

            Student? createdStudent = await _schoolRepo.Student.GetByCodeAsync(studentEntity.Code);

            if (createdStudent == null)
            {
                return await WrapperResult<CreateStudentResponse>.FailAsync(new ErrorModel()
                {
                    Message = "Can't create the student."
                });
            }

            return await WrapperResult<CreateStudentResponse>
                .SuccessAsync(new CreateStudentResponse()
                {
                    Id = createdStudent.Id,
                    Code = createdStudent.Code,
                });
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
