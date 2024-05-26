using FluentValidation;
using Source.Shared.Common.Helpers;
using Source.Shared.Wrapper;

namespace Source.Shared.Extensions.FluentValidation;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TEnum> IsInEnumExcept<T, TEnum>(
        this IRuleBuilder<T, TEnum> ruleBuilder,
        params TEnum[] exceptValues)
    {
        IEnumerable<string?> validValues = EnumHelper.GetEnumValues<TEnum>()
            .Except(exceptValues.Select(x => x?.ToString()));

        return ruleBuilder.IsInEnum();
    }

    public static IRuleBuilderOptions<T, TProperty> WithCustomError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule,
        ErrorModel error)
    {
        rule.WithState(_ => error);
        return rule;
    }

    public static IRuleBuilderOptions<T, TProperty> WithCustomError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule,
        Func<Task<ErrorModel>> errorTask)
    {
        rule.WithState(_ => errorTask);
        return rule;
    }
}
