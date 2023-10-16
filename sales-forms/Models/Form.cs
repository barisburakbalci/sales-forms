using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required long ClientId {  get; set; }

        [ForeignKey("ClientId"), JsonIgnore]
        public Client? Client { get; set; }

        public ICollection<Question>? Questions { get; }
    }
}