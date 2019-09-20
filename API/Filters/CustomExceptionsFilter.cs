using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Model.Pattern;

namespace Api.Filters
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public class CustomExceptionsFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="logger">Logger</param>
        public CustomExceptionsFilter(ILogger<CustomExceptionsFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// On Exception Pipeline
        /// </summary>
        /// <param name="context">Exception Context</param>
        public void OnException(ExceptionContext context)
        {
            var customReturn = CustomReturn.ExceptionReturn(context.HttpContext.Request, context.Exception);

            context.HttpContext.Response.StatusCode = customReturn.Status.Value;
            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new BadRequestObjectResult(customReturn);

            _logger.LogError(context.Exception, customReturn.Detail);
        }
    }
}
