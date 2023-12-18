
using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;
using AutoMapper;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : GenericControllerBase<AppUser, CreateAppUserVM, UpdateAppUserVM>
    {
        public AppUserController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
