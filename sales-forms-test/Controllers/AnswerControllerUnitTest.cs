using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;

namespace sales_forms_test.Controllers
{
    public class AnswerControllerTests
    {
        private readonly AnswerController _controller;
        private readonly FormDbContext _dbContext;
        public AnswerControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateAnswer_Valid()
        {
            Answer answer = GetDummyAnswer();

            Answer? createdAnswer = _controller.Post(answer);

            Assert.That(createdAnswer, Is.Not.Null);
            Assert.That(createdAnswer.Value, Is.EqualTo(answer.Value));
        }

        [Test]
        public void UpdateAnswer_Valid()
        {
            Answer answer = GetDummyAnswer();
 
            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            Answer updatedAnswer = new()
            {
                ParticipantId = 1,
                QuestionId = 1,
                Value = "200 metre",
                Weight = 10
            };


            var response = _controller.Put(answer.Id, updatedAnswer);
            Assert.That(response, Is.InstanceOf<Answer>());
        }

        [Test]
        public void UpdateAnswer_NotFound()
        {
            Answer answer = GetDummyAnswer();

            var response = _controller.Put(100, answer);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteAnswer_Valid()
        {
            Answer lastAnswer = GetDummyAnswer();

            _dbContext.Answers.Add(lastAnswer);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastAnswer.Id);
            Assert.That(response, Is.InstanceOf<Answer>());
        }

        [Test]
        public void DeleteAnswer_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetAnswers()
        {
            Answer answer = GetDummyAnswer();

            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();
            IEnumerable<Answer> answers = _controller.Get();


            Assert.That(answers.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetAnswer_Valid()
        {
            Answer answer = GetDummyAnswer();

            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            var response = _controller.Get(answer.Id);
            Assert.That(response, Is.InstanceOf<Answer>());
        }

        [Test]
        public void GetAnswer_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        private static Answer GetDummyAnswer()
        {
            Answer answer = new()
            {
                Value = "100 metre",
                Weight = 10,
                ParticipantId = 1,
                QuestionId = 1,
            };

            return answer;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}