using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Client Client { get; set; }
        public ICollection<Question>? Questions { get; }
    }
}