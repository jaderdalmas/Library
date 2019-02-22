using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Api.Filters
{
    /// <summary>
    /// Size Limit of a Request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequestSizeLimitAttribute : Attribute, IAuthorizationFilter
    {
        private readonly FormOptions _formOptions;

        /// <summary>
        /// Size Limit on Request
        /// </summary>
        /// <param name="keyLengthLimit"></param>
        /// <param name="valueCountLimit"></param>
        /// <param name="valueLengthLimit"></param>
        public RequestSizeLimitAttribute(int keyLengthLimit = 1024*16, int valueCountLimit = 1024, int valueLengthLimit = 1024)
        {
            _formOptions = new FormOptions()
            {
                KeyLengthLimit = keyLengthLimit,
                ValueCountLimit = valueCountLimit,
                ValueLengthLimit = valueLengthLimit
                // MultipartBodyLengthLimit = valueCountLimit
            };
        }

        /// <summary>
        /// On Authorize set limits
        /// </summary>
        /// <param name="context">Authorization Context</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var contextFeatures = context.HttpContext.Features;
            var formFeature = contextFeatures.Get<IFormFeature>();

            if (formFeature == null || formFeature.Form == null)
            { // Setting length limit when the form request is not yet being read
                contextFeatures.Set<IFormFeature>(new FormFeature(context.HttpContext.Request, _formOptions));
            }
        }
    }
}