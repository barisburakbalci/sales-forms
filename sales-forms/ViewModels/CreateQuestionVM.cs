using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateQuestionVM
    {
        [Required]
        public required string Expression { get; set; }

        [Required]
        public required long FormId { get; set; }

        public static explicit operator Question(CreateQuestionVM questionVM)
        {
            return new Question
            {
                Expression = questionVM.Expression,
                FormId = questionVM.FormId
            };
        }
    }
}
