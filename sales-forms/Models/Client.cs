using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace sales_forms.Models
{
    public class Client : IdentityUser<long>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public ICollection<Form>? Forms { get; }
    }
}