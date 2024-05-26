using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Source.Shared.Providers;

public class BindListObjectModelProvider : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        string value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

        if (string.IsNullOrWhiteSpace(value))
        {
            bindingContext.Result = ModelBindingResult.Success(null);
            return Task.CompletedTask;
        }

        if (!value[0].Equals('['))
            value = "[" + value + "]";

        Type elementType = bindingContext.ModelType;

        bindingContext.Model = JsonConvert.DeserializeObject(value, elementType);

        bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);

        return Task.CompletedTask;
    }
}
