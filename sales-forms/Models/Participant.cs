using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Answer>? Answers { get; }
        public int Score { get; set; }
    }
}