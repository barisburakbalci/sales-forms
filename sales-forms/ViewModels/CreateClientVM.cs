using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class CreateClientVM
    {
        [Required]
        public required string Name { get; set; }
    }
}
