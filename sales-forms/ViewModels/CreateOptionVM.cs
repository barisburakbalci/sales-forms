using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class CreateOptionVM
    {
        [Required]
        public long QuestionId { get; set; }

        [Required]
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }
    }
}
