using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;

namespace sales_forms_test.Controllers
{
    public class ParticipantControllerTests
    {
        private readonly ParticipantController _controller;
        private readonly FormDbContext _dbContext;
        public ParticipantControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateParticipant_Valid()
        {
            Participant participant = GetDummyParticipant();

            Participant? createdParticipant = _controller.Post(participant);

            Assert.That(createdParticipant, Is.Not.Null);
            Assert.That(createdParticipant.Name, Is.EqualTo(participant.Name));
        }

        [Test]
        public void UpdateParticipant_Valid()
        {
            Participant participant = GetDummyParticipant();
 
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            Participant updatedParticipant = new()
            {
                Name = "Updated Participant",
            };


            var response = _controller.Put(participant.Id, updatedParticipant);
            Assert.That(response, Is.InstanceOf<Participant>());
        }

        [Test]
        public void UpdateParticipant_NotFound()
        {
            Participant participant = GetDummyParticipant();

            var response = _controller.Put(100, participant);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteParticipant_Valid()
        {
            Participant lastParticipant = GetDummyParticipant();

            _dbContext.Participants.Add(lastParticipant);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastParticipant.Id);
            Assert.That(response, Is.InstanceOf<Participant>());
        }

        [Test]
        public void DeleteParticipant_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetParticipants()
        {
            Participant participant = GetDummyParticipant();

            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();
            IEnumerable<Participant> participants = _controller.Get();


            Assert.That(participants.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetParticipant_Valid()
        {
            Participant participant = GetDummyParticipant();

            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            var response = _controller.Get(participant.Id);
            Assert.That(response, Is.InstanceOf<Participant>());
        }

        [Test]
        public void GetParticipant_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        private static Participant GetDummyParticipant()
        {
            Participant participant = new()
            {
                Name = "Dummy Participant",
            };

            return participant;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}