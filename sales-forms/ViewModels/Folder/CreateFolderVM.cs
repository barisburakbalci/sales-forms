using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateFolderVM
    {
        [Required]
        public required string Name { get; set; }

        public static explicit operator Folder(CreateFolderVM folderVM)
        {
            return new Folder
            {
                Name = folderVM.Name
            };
        }
    }
}
