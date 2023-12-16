using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateAnswerVM : ViewModelBase, IUpdateVM
    {
        public long Id { get; set; }
        public long? ParticipantId { get; set; }

        public long? QuestionId { get; set; }

        public long? OptionId { get; set; }
    }
}
