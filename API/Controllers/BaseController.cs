using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    //[Authorize(Authorization.Policy), Authorize(Roles = "lf_admin,lf_cadastro,lf_ec")]
    //[EnableCors(Cors.Policy)]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Book Service
        /// </summary>
        protected IBookService Service { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookService">Book Service</param>
        public BaseController(IBookService bookService = null)
        {
            Service = bookService;
        }
    }
}
