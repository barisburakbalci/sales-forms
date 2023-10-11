using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;
using System.Reflection;

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
        public Answer? Get(long id)
        {
            return _dbContext.Answers.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Answer? Post([FromBody] CreateAnswerVM answerData)
        {
            Answer answer = (Answer)answerData;
            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            return answer;
        }

        [HttpPut("{id}")]
        public Answer? Put(long id, [FromBody] UpdateAnswerVM answer)
        {
            var existingAnswer = _dbContext.Answers.SingleOrDefault(q => q.Id == id);

            if (existingAnswer != null)
            {
                _dbContext.Answers.Entry(existingAnswer).CurrentValues.SetValues(answer.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingAnswer;
        }

        [HttpDelete("{id}")]
        public Answer? Delete(long id)
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
