using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
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
