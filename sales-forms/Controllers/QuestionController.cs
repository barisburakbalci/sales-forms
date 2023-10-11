
using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;

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
        public Question? Get(long id)
        {
            return _dbContext.Questions.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Question? Post([FromBody] CreateQuestionVM questionData)
        {
            Question question = (Question)questionData;
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            return question;
        }

        [HttpPut("{id}")]
        public Question? Put(long id, [FromBody] UpdateQuestionVM question)
        {
            var existingQuestion = _dbContext.Questions.SingleOrDefault(q => q.Id == id);

            if (existingQuestion != null)
            {
                _dbContext.Questions.Entry(existingQuestion).CurrentValues.SetValues(question.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingQuestion;
        }

        [HttpDelete("{id}")]
        public Question? Delete(long id)
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
