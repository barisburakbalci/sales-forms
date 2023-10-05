using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required Client Client { get; set; }

        public ICollection<Question>? Questions { get; }
    }
}