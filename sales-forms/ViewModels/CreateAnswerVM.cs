using System.ComponentModel.DataAnnotations;

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
    }
}
