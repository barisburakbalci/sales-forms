using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace sales_forms.Models
{
	public class AppUser : IdentityUser<long>
	{
        [Required]
        public required string Name { get; set; }
    }
}

