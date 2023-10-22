using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateFormVM : ViewModelBase
    {
        public string? Name { get; set; }
        public long? FolderId { get; set; }
    }
}
