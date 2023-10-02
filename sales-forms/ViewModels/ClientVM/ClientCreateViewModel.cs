using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels.ClientVM
{
    public class ClientCreateViewModel
    {
        [Required(ErrorMessage = "Name is required for Client")]
        public required string Name { get; set; }
    }
}
