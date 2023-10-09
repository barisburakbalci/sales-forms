using Microsoft.AspNetCore.Mvc;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        public FormDbContext _dbContext;

        public FormController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Form> Get()
        {
            return _dbContext.Forms.ToList();
        }

        [HttpGet("{id}")]
        public Form? Get(long id)
        {
            Form? form = _dbContext.Forms.SingleOrDefault(q => q.Id == id);

            return form;
        }

        [HttpPost]
        public Form? Post([FromBody] CreateFormVM formData)
        {
            Form form = (Form)formData;
            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();
            return form;
        }

        [HttpPut("{id}")]
        public Form? Put(long id, [FromBody] UpdateFormVM form)
        {
            Form? existingForm = _dbContext.Forms.SingleOrDefault(q => q.Id == id);

            if (existingForm != null)
            {
                _dbContext.Forms.Entry(existingForm).CurrentValues.SetValues(form);
                _dbContext.SaveChanges();
            }


            return existingForm;
        }

        [HttpDelete("{id}")]
        public Form? Delete(long id)
        {
            var existingForm = _dbContext.Forms.SingleOrDefault(q => q.Id == id);

            if (existingForm != null)
            {
                _dbContext.Forms.Remove(existingForm);
                _dbContext.SaveChanges();
            }

            return existingForm;
        }
    }
}

