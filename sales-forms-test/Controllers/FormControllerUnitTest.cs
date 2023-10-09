using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class FormControllerTests
    {
        private readonly FormController _controller;
        private readonly FormDbContext _dbContext;
        public FormControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateForm_Valid()
        {
            CreateFormVM form = new()
            {
                Name = "Dummy Form",
                ClientId = 1,
            };

            Form? createdForm = _controller.Post(form);

            Assert.That(createdForm, Is.Not.Null);
            Assert.That(createdForm.Name, Is.EqualTo(form.Name));
        }

        [Test]
        public void UpdateForm_Valid()
        {
            Form form = GetDummyForm();
 
            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();

            UpdateFormVM updatedForm = new()
            {
                Name = "Updated Form",
                ClientId = 1,
            };


            var response = _controller.Put(form.Id, updatedForm);
            Assert.That(response, Is.InstanceOf<Form>());
        }

        [Test]
        public void UpdateForm_NotFound()
        {
            UpdateFormVM form = new()
            {
                Name = "Dummy Form",
                ClientId = 1,
            };

            var response = _controller.Put(100, form);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteForm_Valid()
        {
            Form lastForm = GetDummyForm();

            _dbContext.Forms.Add(lastForm);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastForm.Id);
            Assert.That(response, Is.InstanceOf<Form>());
        }

        [Test]
        public void DeleteForm_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetForms()
        {
            Form form = GetDummyForm();

            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();
            IEnumerable<Form> forms = _controller.Get();


            Assert.That(forms.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetForm_Valid()
        {
            Form form = GetDummyForm();

            _dbContext.Forms.Add(form);
            _dbContext.SaveChanges();

            var response = _controller.Get(form.Id);
            Assert.That(response, Is.InstanceOf<Form>());
        }

        [Test]
        public void GetForm_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        private static Form GetDummyForm()
        {
            Form form = new()
            {
                Name = "Dummy Form",
                ClientId = 1,
            };

            return form;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}