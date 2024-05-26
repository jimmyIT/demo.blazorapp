using FluentValidation;
using Source.Shared.Wrapper;

namespace Source.Shared.Validator;

public interface IFluentValidator<TModel> : IValidator<TModel> where TModel : class
{
    Task<ValidationResultModel> DoActionAsync(TModel model);
}
