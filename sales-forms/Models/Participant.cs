using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Participant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private init; }

        [Required]
        public required string Name { get; set; }

        public ICollection<Answer>? Answers { get; }

        public int Score { get; set; }
    }
}