﻿namespace sales_forms.Models
{
    public class Option
    {
        public int Id { get; set; }
        public required Question Question { get; set; }
        public required string Value { get; set; }
        public int Weight { get; set; }
    }
}