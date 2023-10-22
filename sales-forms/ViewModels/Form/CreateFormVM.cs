using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateFormVM
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required long FolderId { get; set; }

        public static explicit operator Form(CreateFormVM formVM)
        {
            return new Form
            {
                Name = formVM.Name,
                FolderId = formVM.FolderId
            };
        }
    }
}
