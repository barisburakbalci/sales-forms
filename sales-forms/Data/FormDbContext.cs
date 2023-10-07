﻿using Microsoft.EntityFrameworkCore;
using sales_forms.Models;

namespace sales_forms.Data
{
	public class FormDbContext : DbContext
	{
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}

