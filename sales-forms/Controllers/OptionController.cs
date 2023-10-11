using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        public FormDbContext _dbContext;

        public OptionController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Option> Get()
        {
            return _dbContext.Options.ToList();
        }

        [HttpGet("{id}")]
        public Option? Get(long id)
        {
            return _dbContext.Options.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public Option? Post([FromBody] CreateOptionVM optionData)
        {
            Option option = (Option)optionData;
            _dbContext.Options.Add(option);
            _dbContext.SaveChanges();

            return option;
        }

        [HttpPut("{id}")]
        public Option? Put(long id, [FromBody] UpdateOptionVM option)
        {
            var existingOption = _dbContext.Options.SingleOrDefault(q => q.Id == id);

            if (existingOption != null)
            {
                _dbContext.Options.Entry(existingOption).CurrentValues.SetValues(option.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingOption;
        }

        [HttpDelete("{id}")]
        public Option? Delete(long id)
        {
            var existingOption = _dbContext.Options.SingleOrDefault(q => q.Id == id);

            if (existingOption != null)
            {
                _dbContext.Options.Remove(existingOption);
                _dbContext.SaveChanges();
            }

            return existingOption;
        }
    }
}
