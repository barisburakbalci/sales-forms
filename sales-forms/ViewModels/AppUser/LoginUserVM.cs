using System;
using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
	public class LoginUserVM
	{
        [EmailAddress]
        public required string Email;

        [Required, MinLength(6), MaxLength(12)]
        public required string Password;
    }
}

