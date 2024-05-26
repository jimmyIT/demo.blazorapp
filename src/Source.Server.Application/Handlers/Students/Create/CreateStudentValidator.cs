using FluentValidation;
using Source.Server.Application.Common.Provider;
using Source.Shared.Validator;

namespace Source.Server.Application.Handlers.Students.Create;
public interface ICreateStudentValidator : IFluentValidator<CreateStudentRequest>
{
}

public class CreateStudentValidator
    : FluentValidator<CreateStudentRequest>, ICreateStudentValidator
{
    private readonly IValidationProvider _validationProvider;

    public CreateStudentValidator(
        IValidationProvider validationProvider)
    {
        _validationProvider = validationProvider;

        RuleFor(request => request.Name)
            .NotEmpty()
            .NotNull()
            .Length(
                _validationProvider.MinLength,
                _validationProvider.MaxLength);

        RuleFor(request => request.DateOfBirth)
            .NotEmpty()
            .NotNull();

        RuleFor(request => request.UserName)
            .NotEmpty()
            .NotNull()
            .Length(
                _validationProvider.MinLength,
                _validationProvider.MaxLength)
            .Matches(_validationProvider.EmailAddressRegex);

        RuleFor(request => request.Password)
            .NotEmpty()
            .NotNull()
            .Length(
                _validationProvider.MinPasswordLength,
                _validationProvider.MaxPasswordLength);
    }
}
