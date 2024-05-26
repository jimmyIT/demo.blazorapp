using FluentValidation;
using Source.Server.Application.Common.Provider;
using Source.Shared.Validator;

namespace Source.Server.Application.Handlers.UserProfiles.Create;
public interface ICreateUserProfilesValidator : IFluentValidator<CreateUserProfilesRequest>
{
}
public class CreateUserProfilesValidator
    : FluentValidator<CreateUserProfilesRequest>, ICreateUserProfilesValidator
{
    public CreateUserProfilesValidator(
        IValidationProvider validationProvider)
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(50);

        RuleFor(request => request.DateOfBirth).NotNull();

        RuleFor(request => request.EmailAddress)
            .NotEmpty()
            .NotNull()
            .MinimumLength(50)
            .Matches(validationProvider.EmailAddressRegex);
    }
}
