using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Folder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public ICollection<Form>? Forms { get; }

        public ICollection<FolderPermission>? Permissions { get; }
    }
}