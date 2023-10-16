using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateFormVM : ViewModelBase
    {
        public string? Name { get; set; }
        public string? ClientId { get; set; }
    }
}
