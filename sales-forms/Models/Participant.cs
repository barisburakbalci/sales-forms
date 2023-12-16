using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Participant : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public ICollection<Answer>? Answers { get; }
    }
}