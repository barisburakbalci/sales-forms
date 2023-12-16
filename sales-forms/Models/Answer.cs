using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Answer : BaseEntity
    {
        [Required]
        public required long ParticipantId { get; set; }

        [ForeignKey("ParticipantId"), JsonIgnore]
        public Participant? Participant { get; set; }

        [Required]
        public required long QuestionId { get; set; }
        
        [ForeignKey("QuestionId"), JsonIgnore]
        public Question? Question { get; set; }

        [Required]
        public required long OptionId { get; set; }

        [ForeignKey("QuestionId"), JsonIgnore]
        public Option? Option { get; set; }
    }
}