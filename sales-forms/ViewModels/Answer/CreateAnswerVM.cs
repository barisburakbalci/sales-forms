using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateAnswerVM
    {
        [Required]
        public required long ParticipantId { get; set; }

        [Required]
        public required long QuestionId { get; set; }

        [Required]
        public required long OptionId { get; set; }

        public static explicit operator Answer(CreateAnswerVM answerVM)
        {
            return new Answer
            {
                ParticipantId = answerVM.ParticipantId,
                QuestionId = answerVM.QuestionId,
                OptionId = answerVM.OptionId
            };
        }
    }
}
