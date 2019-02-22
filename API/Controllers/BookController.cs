using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
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
            //BookService.
            var rep = new KotlinLangRepository();
            return Ok(await rep.GetBooks());
        }

        [HttpGet("{id}"), ProducesResponseType(201, Type = typeof(BookDTO))]
        public IActionResult Get(int id)
        {
            return Ok("value");
        }

        [HttpPost, ProducesResponseType(201, Type = typeof(BookDTO))]
        public IActionResult Post([FromBody] BookRequest value)
        {
            var response = new BookDTO();
            return Created(string.Format("api/book/{0}", response.ID), value);
        }
    }
}
