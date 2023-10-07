using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateFormVM
    {
        public string? Name { get; set; }
        public long? ClientId { get; set; }
    }
}
