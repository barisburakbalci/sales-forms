using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;
using AutoMapper;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        public FormDbContext _dbContext;
        public IMapper _mapper;

        public AnswerController(FormDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Answer> Get()
        {
            return _dbSet.ToList();
        }

        [HttpGet("{id}")]
        public Answer? Get(long id)
        {
            return _dbSet.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Answer? Post([FromBody] CreateAnswerVM answerData)
        {
            Answer answer = _mapper.Map<Answer>(answerData);
            _dbSet.Add(answer);
            _dbContext.SaveChanges();

            return answer;
        }

        [HttpPut("{id}")]
        public Answer? Put([FromBody] UpdateAnswerVM answer)
        {
            Answer? existingAnswer = _dbSet.SingleOrDefault(q => q.Id == answer.Id);

            if (existingAnswer != null)
            {
                _dbSet.Entry(existingAnswer).CurrentValues.SetValues(answer);
                _dbContext.SaveChanges();
            }

            return existingAnswer;
        }

        [HttpDelete("{id}")]
        public Answer? Delete(long id)
        {
            var existingAnswer = _dbSet.SingleOrDefault(q => q.Id == id);

            if (existingAnswer != null)
            {
                _dbSet.Remove(existingAnswer);
                _dbContext.SaveChanges();
            }

            return existingAnswer;
        }
    }
}
