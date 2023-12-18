using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
	public class UpdateAppUserVM : UpdateVM
	{
        public string? Name { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		public string? Password { get; set; }
    }
}

