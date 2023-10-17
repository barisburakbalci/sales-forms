using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasData(new Client
                {
                    Id = 1,
                    Name = "Test Client"
                });

            modelBuilder.Entity<Form>()
                .HasData(new Form
                {
                    Id = 1,
                    ClientId = 1,
                    Name = "Test Form"
                });

            modelBuilder.Entity<Question>()
                .HasData(new Question
                {
                    Id = 1,
                    FormId = 1,
                    Expression = "Test Question"
                });

            modelBuilder.Entity<Option>()
                .HasData(new Option
                {
                    Id = 1,
                    QuestionId = 1,
                    Value = "Test Option",
                    Weight = 10
                });

            modelBuilder.Entity<Participant>()
                .HasData(new Participant
                {
                    Id = 1,
                    Name = "Test Participant"
                });

            modelBuilder.Entity<Answer>()
                .HasData(new Answer()
                {
                    Id = 1,
                    ParticipantId = 1,
                    QuestionId = 1,
                    OptionId = 1
                });
        }
    }
}

