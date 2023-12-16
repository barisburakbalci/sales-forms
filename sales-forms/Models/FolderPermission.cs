using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Models
{
    [PrimaryKey(nameof(FolderId), nameof(AppUserId))]
	public class FolderPermission : BaseEntity
	{
        [ForeignKey("FolderId"), JsonIgnore]
        public Folder? Folder { get; set; }

        [Required]
        public required long AppUserId { get; set; }

        [ForeignKey("UserId"), JsonIgnore]
        public AppUser? AppUser { get; set; }

        public AccessType AccessType { get; set; } = AccessType.Read;
    }

    public enum AccessType
    {
        Read,
        Write,
        Delete
    }
}

