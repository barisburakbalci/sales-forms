using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class CreateQuestionVM
    {
        [Required]
        public required string Expression { get; set; }

        [Required]
        public required long FormId { get; set; }
    }
}
