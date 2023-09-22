using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Option
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required Question Question { get; set; }
        public required string Value { get; set; }
        public int Weight { get; set; }
    }
}