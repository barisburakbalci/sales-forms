using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sales_forms.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required Participant Participant { get; set; }
        public required Question Question { get; set; }
        public required string Value { get; set; }
        public int Weight { get; set; }
    }
}