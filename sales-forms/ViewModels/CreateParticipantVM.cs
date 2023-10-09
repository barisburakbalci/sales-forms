using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateParticipantVM
    {
        [Required]
        public required string Name { get; set; }

        public static explicit operator Participant(CreateParticipantVM participantVM)
        {
            return new Participant
            {
                Name = participantVM.Name
            };
        }
    }
}
