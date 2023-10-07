using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class CreateFormVM
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required long ClientId { get; set; }
    }
}
