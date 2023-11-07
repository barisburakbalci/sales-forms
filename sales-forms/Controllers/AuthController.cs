
using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public FormDbContext _dbContext;

        public AuthController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserVM loginVM)
        {
            string? password = (
                from user in _dbContext.AppUsers
                where user.Email == loginVM.Email
                select user.PasswordHash
            ).SingleOrDefault();

            // TODO: Hash passwords with a Custom Hash Service
            if (password != null && password == loginVM.Password)
            {
                return Ok("Login Success!");
            }

            return BadRequest("Credentials are incorrect!");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateAppUserVM registerUserVM)
        {
            // TODO: Use register instead of AppUser::Post
            return Ok();
        }
    }
}
