using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Form>? Forms { get; }
    }
}