﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_forms.Models
{
    public class Form
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private init; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required long ClientId {  get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }

        public ICollection<Question>? Questions { get; }
    }
}