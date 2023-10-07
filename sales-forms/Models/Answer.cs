using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sales_forms.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private init; }

        [Required]
        public required long ParticipantId { get; set; }

        [ForeignKey("ParticipantId")]
        public Participant? Participant { get; private set; }

        [Required]
        public required long QuestionId { get; set; }
        
        [ForeignKey("QuestionId")]
        public Question? Question { get; private set; }

        [Required]
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }
    }
}