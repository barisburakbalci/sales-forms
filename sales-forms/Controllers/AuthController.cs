
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
        public async Task<IActionResult> Register([FromBody] CreateAppUserVM registerUserVM)
        {
            IdentityResult registrationResult = await _userManager.CreateAsync(
                new AppUser()
                {
                    Name = registerUserVM.Name,
                    Email = registerUserVM.Email,
                },
                registerUserVM.Password
            );

            if (registrationResult.Succeeded)
            {
                return Ok("The user is registrated.");
            }

            return BadRequest("Given data is incompatible for registrating a user.");
        }
    }
}
