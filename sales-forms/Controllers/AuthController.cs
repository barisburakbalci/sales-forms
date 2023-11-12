
using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login"), Authorize]
        public async Task<IActionResult> Login([FromBody] LoginUserVM loginVM)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, false, false);

            if (signInResult.Succeeded)
            {
                return Ok("Başarılı giriş.");
            }

            return BadRequest("Girilen bilgiler yanlış!");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateAppUserVM registerUserVM)
        {
            _userManager.CreateAsync(
                new() {
                    Name = registerUserVM.Name,
                    Email = registerUserVM.Email,
                },
                registerUserVM.Password
            );

            return Ok();
        }
    }
}
