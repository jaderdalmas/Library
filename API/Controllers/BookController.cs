using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        public BookController(IBookService service) : base(service) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Service.GetBooks());
        }

        [HttpGet("{id}"), ProducesResponseType(201, Type = typeof(BookDTO))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(Service.GetBookById(id));
        }

        [HttpPost, ProducesResponseType(201, Type = typeof(BookDTO))]
        public async Task<IActionResult> Post([FromBody] BookRequest value)
        {
            return Created(string.Format("api/book/{0}", Service.PostBook(value).ID), value);
        }
    }
}
