using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string Expression { get; set; }

        [Required]
        public required long FormId { get; set; }

        [ForeignKey("FormId"), JsonIgnore]
        public Form? Form { get; set; }

        public ICollection<Answer>? Answers { get; }
        public ICollection<Option>? Options {  get; }
    }
}
