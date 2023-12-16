using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sales_forms.Models
{
    public class Form : BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required long FolderId {  get; set; }

        [ForeignKey("FolderId"), JsonIgnore]
        public Folder? Folder { get; set; }

        public ICollection<Question>? Questions { get; }
    }
}