using FluentValidation;
using WebApp.Application.Common.Validation.Fluent;

namespace WebApp.Application.Models.IdentityPages.Signin;

public class SignInModelValidator : BaseAbstractValidator<SignInModel>
{
    public SignInModelValidator()
    {
        RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MustAsync(async (value, cancellationToken) => await CheckExistAsync(value));

        RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();
    }

    private async Task<bool> CheckExistAsync(string email)
    {
        // Simulates a long running http call
        await Task.Delay(2000);

        return true;
    }
}
