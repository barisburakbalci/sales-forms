﻿using System.ComponentModel.DataAnnotations;

namespace sales_forms.ViewModels
{
    public class UpdateQuestionVM
    {
        public string? Expression { get; set; }
        public long? FormId { get; set; }
    }
}
