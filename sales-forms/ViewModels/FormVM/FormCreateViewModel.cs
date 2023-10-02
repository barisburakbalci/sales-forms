using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels.FormVM
{
    public class FormCreateViewModel
    {
        [Required(ErrorMessage = "Name is required for Client")]
        public required string Name { get; set; }

        [Required]
        public required Client Client { get; set; }
    }
}
