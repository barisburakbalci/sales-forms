using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private init; }

        [Required]
        public required long ParticipantId { get; set; }

        [ForeignKey("ParticipantId"), JsonIgnore]
        public Participant? Participant { get; private set; }

        [Required]
        public required long QuestionId { get; set; }
        
        [ForeignKey("QuestionId"), JsonIgnore]
        public Question? Question { get; private set; }

        [Required]
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }
    }
}