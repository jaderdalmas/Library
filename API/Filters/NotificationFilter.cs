using Microsoft.AspNetCore.Mvc.Filters;
using Model.Pattern;
using System.Threading.Tasks;

namespace Api.Filters
{
    /// <summary>
    /// Exception Filter
    /// </summary>
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotification notificationContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="notificationContext">Notification Context</param>
        public NotificationFilter(INotification notificationContext)
        {
            this.notificationContext = notificationContext;
        }

        /// <summary>
        /// On Notification Result
        /// </summary>
        /// <param name="context">Exception Context</param>
        /// <param name="next">Next Execution</param>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!notificationContext.HasReturn) await next();
            else await CustomReturn.PutResponse(context.HttpContext.Response,
                CustomReturn.NotificationReturn(context.HttpContext.Request, notificationContext));
        }
    }
}
