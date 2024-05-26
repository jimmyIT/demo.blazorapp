using FluentValidation;
using WebApp.Application.Common.Validation.Fluent;

namespace WebApp.Application.Models.IdentityPages.Register;

public class RegistrationDetailsValidator : BaseAbstractValidator<RegistrationDetailsModel>
{
    public RegistrationDetailsValidator()
    {
        RuleFor(x => x.EmailAddress)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

        RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

        RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

        RuleFor(x => x.PhoneIDD)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

        RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

        RuleFor(x => x.DateOfBirth)
                .Cascade(CascadeMode.Stop)
                .NotNull();
    }
}
