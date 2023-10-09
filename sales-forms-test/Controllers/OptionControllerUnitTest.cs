using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class OptionControllerTests
    {
        private readonly OptionController _controller;
        private readonly FormDbContext _dbContext;
        public OptionControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateOption_Valid()
        {
            CreateOptionVM option = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };

            Option? createdOption = _controller.Post(option);

            Assert.That(createdOption, Is.Not.Null);
            Assert.That(createdOption.Value, Is.EqualTo(option.Value));
        }

        [Test]
        public void UpdateOption_Valid()
        {
            Option option = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };
 
            _dbContext.Options.Add(option);
            _dbContext.SaveChanges();

            UpdateOptionVM updatedOption = new()
            {
                QuestionId = 1,
                Value = "200 metre",
                Weight = 10
            };


            var response = _controller.Put(option.Id, updatedOption);
            Assert.That(response, Is.InstanceOf<Option>());
        }

        [Test]
        public void UpdateOption_NotFound()
        {
            UpdateOptionVM option = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };

            var response = _controller.Put(100, option);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteOption_Valid()
        {
            Option lastOption = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };

            _dbContext.Options.Add(lastOption);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastOption.Id);
            Assert.That(response, Is.InstanceOf<Option>());
        }

        [Test]
        public void DeleteOption_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetOptions()
        {
            Option option = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };

            _dbContext.Options.Add(option);
            _dbContext.SaveChanges();
            IEnumerable<Option> options = _controller.Get();


            Assert.That(options.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetOption_Valid()
        {
            Option option = new()
            {
                Value = "100 metre",
                Weight = 10,
                QuestionId = 1,
            };

            _dbContext.Options.Add(option);
            _dbContext.SaveChanges();

            var response = _controller.Get(option.Id);
            Assert.That(response, Is.InstanceOf<Option>());
        }

        [Test]
        public void GetOption_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}