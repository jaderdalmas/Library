using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Api.Filters
{
    /// <summary>
    /// Validate Parameters o Action
    /// </summary>
    public class ValidateActionParametersAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// On Action Executing
        /// </summary>
        /// <param name="context">Action Executing Context</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();
                foreach (var parameter in parameters)
                {
                    var argument = context.ActionArguments[parameter.Name];

                    EvaluateValidationAttributes(parameter, argument, context.ModelState);
                }
            }

            (new ValidateModelStateAttribute()).OnActionExecuting(context);
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Evaliate Atribute Validation
        /// </summary>
        /// <param name="parameter">Parameter Info</param>
        /// <param name="argument">Object</param>
        /// <param name="modelState">Model State</param>
        private void EvaluateValidationAttributes(ParameterInfo parameter, object argument, ModelStateDictionary modelState)
        {
            var validationAttributes = parameter.CustomAttributes;
            foreach (var attributeData in validationAttributes)
            {
                var attributeInstance = CustomAttributeExtensions.GetCustomAttribute(parameter, attributeData.AttributeType);

                var validationAttribute = attributeInstance as ValidationAttribute;
                if (validationAttribute != null)
                {
                    var isValid = validationAttribute.IsValid(argument);
                    if (!isValid)
                    {
                        modelState.AddModelError(parameter.Name, validationAttribute.FormatErrorMessage(parameter.Name));
                    }
                }
            }
        }
    }
}
