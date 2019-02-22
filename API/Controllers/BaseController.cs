using Microsoft.AspNetCore.Mvc;
using Service;

namespace Api.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [ApiController]
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
