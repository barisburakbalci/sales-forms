using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : GenericControllerBase<Question, CreateQuestionVM, UpdateQuestionVM>
    {
        public QuestionController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}