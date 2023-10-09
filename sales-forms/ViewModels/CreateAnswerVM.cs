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
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }

        public static explicit operator Answer(CreateAnswerVM answerVM)
        {
            return new Answer
            {
                ParticipantId = answerVM.ParticipantId,
                QuestionId = answerVM.QuestionId,
                Value = answerVM.Value,
                Weight = answerVM.Weight
            };
        }
    }
}
