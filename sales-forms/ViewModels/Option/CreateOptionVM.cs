using System.ComponentModel.DataAnnotations;
using sales_forms.Models;

namespace sales_forms.ViewModels
{
    public class CreateOptionVM
    {
        [Required]
        public long QuestionId { get; set; }

        [Required]
        public required string Value { get; set; }

        [Required]
        public required int Weight { get; set; }

        public static explicit operator Option(CreateOptionVM optionVM)
        {
            return new Option
            {
                Value = optionVM.Value,
                Weight = optionVM.Weight,
                QuestionId = optionVM.QuestionId
            };
        }
    }
}
