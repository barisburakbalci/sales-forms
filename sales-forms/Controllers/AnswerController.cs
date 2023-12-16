using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;
using AutoMapper;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : GenericControllerBase<Answer, CreateAnswerVM, UpdateAnswerVM>
    {
        public AnswerController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
