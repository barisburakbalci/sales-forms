using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateOptionVM : ViewModelBase
    {
        public long? QuestionId { get; set; }
        public string? Value { get; set; }
        public int? Weight { get; set; }
    }
}
