using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class ClientCreateViewModel
    {
        [Required]
        public required string Name {  get; set; }
    }
}
