using FluentValidation;
using FluentValidation.Results;
using Source.Shared.Wrapper;

namespace Source.Shared.Validator;

public class FluentValidator<TModel>
    : AbstractValidator<TModel>, IFluentValidator<TModel> where TModel : class
{
    public FluentValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;
    }

    /// <summary>
    /// Build model's validation rule
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual async Task BuildRulesAsync() => await Task.CompletedTask;
    public async Task<ValidationResultModel> DoActionAsync(TModel model)
    {
        await BuildRulesAsync();

        ValidationResult fluentValidationResult = await ValidateAsync(model);
        
        return await ConvertValidationResultToValidationResultModel(fluentValidationResult);
    }

    protected async Task<ValidationResultModel> ConvertValidationResultToValidationResultModel(ValidationResult fluentValidationResult)
    {
        IList<ErrorModel> errors = new List<ErrorModel>();

        foreach (ValidationFailure? vf in fluentValidationResult.Errors)
        {
            ErrorModel error = new() { Code = vf.ErrorCode, Message = vf.ErrorMessage };

            ErrorModel errorItem = vf.CustomState switch
            {
                ErrorModel errState => errState,
                Func<Task<ErrorModel>> errorTask => await errorTask.Invoke(),
                _ => new() { Code = vf.ErrorCode, Message = vf.ErrorMessage }
            };

            error.Message = errorItem.Message;
            error.Code = errorItem.Code;

            //foreach ((string key, string value) in errorItem.ErrorData)
            //{
            //    error.ErrorData.Add(key, value);
            //}

            //if (vf.FormattedMessagePlaceholderValues?.TryGetValue("CollectionIndex", out object? item) is true &&
            //    item is not null)
            //{
            //    error.ErrorData.AddOrUpdate(CommonErrorProperty.CollectionIndex, item.ToString()!);
            //}

            errors.Add(error);
        }

        return new ValidationResultModel(errors);
    }
}
