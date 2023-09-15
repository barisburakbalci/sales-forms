using Microsoft.EntityFrameworkCore;
using sales_forms.Models;

namespace sales_forms.Data
{
	public class FormDbContext : DbContext
	{
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<Option>().ToTable("Option");
            modelBuilder.Entity<Participant>().ToTable("Participant");
            modelBuilder.Entity<Question>().ToTable("Question");
        }
    }
}

