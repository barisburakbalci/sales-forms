using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string Expression { get; set; }

        [Required]
        public required Form Form { get; set; }

        public ICollection<Answer>? Answers { get; }
        public ICollection<Option>? Options {  get; }
    }
}
