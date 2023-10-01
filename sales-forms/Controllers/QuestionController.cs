using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        public FormDbContext _dbContext;

        public QuestionController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            return _dbContext.Questions.ToList();
        }

        [HttpGet("{id}")]
        public Question? Get(int id)
        {
            return _dbContext.Questions.FirstOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Questions.Add(question);
                _dbContext.SaveChanges();
            }

            return Created("/question/" + question.Id.ToString(), question);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Question question)
        {
            var existingQuestion = _dbContext.Questions.Single<Question>(q => q.Id == id);
            if (ModelState.IsValid)
            {
                _dbContext.Entry(existingQuestion).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingQuestion = _dbContext.Questions.Single<Question>(q => q.Id == id);
            _dbContext.Questions.Remove(existingQuestion);
            _dbContext.SaveChanges();
        }
    }
}
