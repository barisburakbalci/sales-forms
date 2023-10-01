using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        public FormDbContext _dbContext;

        public AnswerController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return _dbContext.Answers.ToList();
        }

        [HttpGet("{id}")]
        public Answer? Get(int id)
        {
            return _dbContext.Answers.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Answer? Post([FromBody] Answer answer)
        {
            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            return answer;
        }

        [HttpPut("{id}")]
        public Answer? Put(int id, [FromBody] Answer answer)
        {
            var existingAnswer = _dbContext.Answers.SingleOrDefault(q => q.Id == id);

            if (existingAnswer != null)
            {
                existingAnswer.Value = answer.Value ?? existingAnswer.Value;
                existingAnswer.Weight = answer.Weight > 0 ? answer.Weight : existingAnswer.Weight;
                _dbContext.SaveChanges();
            }

            return existingAnswer;
        }

        [HttpDelete("{id}")]
        public Answer? Delete(int id)
        {
            var existingAnswer = _dbContext.Answers.SingleOrDefault(q => q.Id == id);

            if (existingAnswer != null)
            {
                _dbContext.Answers.Remove(existingAnswer);
                _dbContext.SaveChanges();
            }

            return existingAnswer;
        }
    }
}
