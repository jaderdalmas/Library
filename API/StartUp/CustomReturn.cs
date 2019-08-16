using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Extension;
using Model.Pattern;
using System.Net;

namespace Api.StartUp
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public static class CustomReturn
    {
        /// <summary>
        /// Notification Return
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="notification">Notification</param>
        /// <returns>Bad Request with Problem Details</returns>
        public static IActionResult NotificationReturn(HttpRequest request, INotification notification)
        {
            var result = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.NoContent,
                Instance = request.GetUri().AbsolutePath,
                Title = "One or more notifications has occurred",
                Detail = notification.GetReturn //Please refer to the errors property for additional details
            };

            if (notification.HasErrors) { result.Status = (int)HttpStatusCode.BadRequest; }
            else if (notification.HasAlerts) { result.Status = (int)HttpStatusCode.NotFound; }

            return new BadRequestObjectResult(result);
        }
    }
}
