#nullable enable
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Resume.Application.Extensions;

namespace Resume.Web.Infrastructure.ModelBinders;

public class PersianDateTimeModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult == ValueProviderResult.None)
            return Task.CompletedTask;

        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

        var valueAsString = valueProviderResult.FirstValue;
        if (string.IsNullOrWhiteSpace(valueAsString))
        {
            if (bindingContext.ModelType == typeof(DateTime?))
            {
                bindingContext.Result = ModelBindingResult.Success(null);
            }
            return Task.CompletedTask;
        }

        var gregorianDate = valueAsString.ToGregorianDateTime();
        if (gregorianDate.HasValue)
        {
            bindingContext.Result = ModelBindingResult.Success(gregorianDate.Value);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "تاریخ وارد شده نامعتبر است.");
        }

        return Task.CompletedTask;
    }
}

public class PersianDateTimeModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
        {
            return new PersianDateTimeModelBinder();
        }

        return null;
    }
}
