using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateFormVM : UpdateVM
    {
        public string? Name { get; set; }
        public long? FolderId { get; set; }
    }
}
