using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Expression { get; set; }
        public required Form Form { get; set; }
        public ICollection<Answer>? Answers { get; }
        public ICollection<Option>? Options {  get; }

    }
}
