using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;

namespace sales_forms_test.Controllers
{
    public class QuestionControllerTests
    {
        private readonly QuestionController _controller;
        private readonly FormDbContext _dbContext;
        public QuestionControllerTests() {
            DbContextOptionsBuilder<FormDbContext> optionBuilder = new();
            optionBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateQuestion_Valid()
        {
            Question question = GetDummyQuestion();

            Question? createdQuestion = _controller.Post(question);

            Assert.That(createdQuestion, Is.Not.Null);
            Assert.That(createdQuestion.Expression, Is.EqualTo(question.Expression));
        }

        [Test]
        public void UpdateQuestion_Valid()
        {
            Question question = GetDummyQuestion();
 
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            Question updatedQuestion = GetDummyQuestion();
            updatedQuestion.Expression = $"{updatedQuestion.Expression} güncellendi";


            var response = _controller.Put(question.Id, updatedQuestion);
            Assert.That(response, Is.InstanceOf<Question>());
        }

        [Test]
        public void UpdateQuestion_NotFound()
        {
            Question question = GetDummyQuestion();

            var response = _controller.Put(100, question);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteQuestion_Valid()
        {
            Question lastQuestion = GetDummyQuestion();

            _dbContext.Questions.Add(lastQuestion);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastQuestion.Id);
            Assert.That(response, Is.InstanceOf<Question>());
        }

        [Test]
        public void DeleteQuestion_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetQuestions()
        {
            Question question = GetDummyQuestion();

            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();
            IEnumerable<Question> questions = _controller.Get();


            Assert.That(questions.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetQuestion_Valid()
        {
            Question question = GetDummyQuestion();
            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            var response = _controller.Get(question.Id);
            Assert.That(response, Is.InstanceOf<Question>());
        }

        [Test]
        public void GetQuestion_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        private Question GetDummyQuestion()
        {
            Question question = new()
            {
                Expression = "Aylýk kaç metre kauçuk satýn alýyor?",
                FormId = 1,
            };

            return question;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}