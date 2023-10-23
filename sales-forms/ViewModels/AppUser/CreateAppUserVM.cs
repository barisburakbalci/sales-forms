using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateAppUserVM
    {
        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public static explicit operator AppUser(CreateAppUserVM userVM)
        {
            return new AppUser
            {
                Name = userVM.Name,
                Email = userVM.Email,
                // TODO: Hash passwords with a Custom Hash Service
                PasswordHash = userVM.Password
            };
        }
    }
}
