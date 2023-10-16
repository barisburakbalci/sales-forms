using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace sales_forms.Models
{
    public class Client : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public ICollection<Form>? Forms { get; }
    }
}