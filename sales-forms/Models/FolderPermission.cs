using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace sales_forms.Models
{
    [PrimaryKey(nameof(FolderId), nameof(UserId))]
	public class FolderPermission
	{
        [Required]
        public required long FolderId { get; set; }

        [ForeignKey("FolderId"), JsonIgnore]
        public Folder? Folder { get; set; }

        [Required]
        public required long UserId { get; set; }

        [ForeignKey("UserId"), JsonIgnore]
        public User? User { get; set; }

        public AccessType AccessType { get; set; } = AccessType.Read;
    }

    public enum AccessType
    {
        Read,
        Write,
        Delete
    }
}

