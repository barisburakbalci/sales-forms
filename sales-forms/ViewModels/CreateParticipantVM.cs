using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class CreateParticipantVM
    {
        [Required]
        public required string Name { get; set; }

        public int Score { get; set; }
    }
}
