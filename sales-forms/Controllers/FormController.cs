using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class FormController : GenericControllerBase<Form, CreateFormVM, UpdateFormVM>
    {
        public FormController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        [HttpGet("{id}/detailed")]
        public List<Form> GetDetailed(long id)
        {
            return _dbContext.Forms
                .Include(form => form.Questions)
                .ThenInclude(question => question.Options)
                .ToList();
        }
    }
}

