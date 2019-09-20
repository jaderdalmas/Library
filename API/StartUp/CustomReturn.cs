using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model.Extension;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace Model.Pattern
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public static class CustomReturn
    {
        private const string Title = "Ocorreu um ou mais erros de validação";

        /// <summary>
        /// Response Details
        /// </summary>
        /// <param name="response">Request</param>
        /// <param name="customReturn">Problem Details</param>
        /// <returns>Response</returns>
        public static Task PutResponse(HttpResponse response, ProblemDetails customReturn)
        {
            response.StatusCode = customReturn.Status.Value;
            response.ContentType = "application/json";

            return response.WriteAsync(JsonConvert.SerializeObject(customReturn));
        }

        /// <summary>
        /// Exception Return
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="exception">Exception</param>
        /// <returns>Problem Details</returns>
        public static ProblemDetails ExceptionReturn(HttpRequest request, Exception exception)
        {
            var result = new ProblemDetails()
            { //Please refer to the errors property for additional details
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = request.GetUri().AbsolutePath,
                Title = Title,
                Detail = $"Message: {exception.Message}\r\n StackTrace: {exception.StackTrace}"
            };

            if (exception is SqlException) { result.Status = (int)HttpStatusCode.PreconditionFailed; }

            return result;
        }

        /// <summary>
        /// ModelState Return
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="modelState">ModelState Dictionary</param>
        /// <returns>Problem Details</returns>
        public static ValidationProblemDetails ModelStateReturn(HttpRequest request, ModelStateDictionary modelState)
        {
            var result = new ValidationProblemDetails(modelState)
            { //Please refer to the errors property for additional details
                Status = (int)HttpStatusCode.BadRequest,
                Instance = request.GetUri().AbsolutePath,
                Title = Title,
                Detail = "Favor observar as propriedades dos erros para mais detalhes"
            };

            return result;
        }

        /// <summary>
        /// Notification Return
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="notification">Notification</param>
        /// <returns>Problem Details</returns>
        public static ProblemDetails NotificationReturn(HttpRequest request, INotification notification)
        {
            var result = new ProblemDetails()
            { //Please refer to the errors property for additional details
                Status = (int)HttpStatusCode.NoContent,
                Instance = request.GetUri().AbsolutePath,
                Title = Title,
                Detail = notification.GetReturn
            };

            if (notification.HasErrors) { result.Status = (int)HttpStatusCode.BadRequest; }
            else if (notification.HasAlerts) { result.Status = (int)HttpStatusCode.PreconditionFailed; }

            return result;
        }
    }
}