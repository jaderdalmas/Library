using Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Api.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service">Book Service</param>
        public BookController(IBookService service) : base(service) { }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns></returns>
        [HttpGet, ProducesResponseType(200, Type = typeof(IEnumerable<BookIntegration>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await Service.GetBooks());
        }

        /// <summary>
        /// Get Book By Id
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Book Dto</returns>
        [HttpGet("{id}"), ValidateActionParameters, ProducesResponseType(201, Type = typeof(BookDto))]
        public async Task<IActionResult> Get([Range(1, int.MaxValue)]int id)
        {
            return Ok(await Service.GetBookById(id));
        }

        /// <summary>
        /// Post Book 
        /// </summary>
        /// <param name="value">Book Request</param>
        /// <returns>Book Dto</returns>
        [HttpPost, ProducesResponseType(200, Type = typeof(BookDto))]
        public async Task<IActionResult> Post([FromBody] BookRequest value)
        {
            var response = await Service.PostBook(value);

            return Created(string.Format("api/book/{0}", response.ID), response);
        }
    }
}
