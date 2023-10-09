using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateClientVM
    {
        [Required]
        public required string Name { get; set; }

        public static explicit operator Client(CreateClientVM clientVM)
        {
            return new Client
            {
                Name = clientVM.Name
            };
        }
    }
}
