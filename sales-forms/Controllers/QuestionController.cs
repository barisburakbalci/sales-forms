using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;

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
            return _dbContext.Questions.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Question? Post([FromBody] Question question)
        {
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            return question;
        }

        [HttpPut("{id}")]
        public Question? Put(int id, [FromBody] Question question)
        {
            var existingQuestion = _dbContext.Questions.SingleOrDefault(q => q.Id == id);

            if (existingQuestion != null)
            {
                existingQuestion.Expression = question.Expression ?? existingQuestion.Expression;
                _dbContext.SaveChanges();
            }

            return existingQuestion;
        }

        [HttpDelete("{id}")]
        public Question? Delete(int id)
        {
            var existingQuestion = _dbContext.Questions.SingleOrDefault(q => q.Id == id);

            if (existingQuestion != null)
            {
                _dbContext.Questions.Remove(existingQuestion);
                _dbContext.SaveChanges();
            }

            return existingQuestion;
        }
    }
}
