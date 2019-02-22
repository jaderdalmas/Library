using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public class CustomExceptionsFilter: IExceptionFilter
    {
        /// <summary>
        /// On Exception Pipeline
        /// </summary>
        /// <param name="context">Exception Context</param>
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            HttpResponse response = context.HttpContext.Response;

            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            context.Result = new JsonResult(new
            {
                message = "Erro ao processar a requisição",
                trace = exception.ToString()
            });
        }
    }
}
