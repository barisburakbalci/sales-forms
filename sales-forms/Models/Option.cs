using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private init; }

        [Required]
        public long QuestionId { get; set; }

        [ForeignKey("QuestionId"), JsonIgnore]
        public Question? Question { get; set; }

        [Required]
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }
    }
}