using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            Question question = new Question()
            {
                Expression = "Dummy question"
            };
            return Created("/linkToCreatedObject", question);
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
