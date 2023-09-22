using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class ClientControllerUnitTest
    {
        private readonly ClientController _controller;
        private readonly FormDbContext _dbContext;
        public ClientControllerUnitTest() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new ClientController(_dbContext);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateClient()
        {
            var response = _controller.Post(new ClientCreateViewModel{ Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<CreatedResult>());
        }

        [Test]
        public void GetClients()
        {
            _dbContext.Clients.Add(new Client{ Name = "Mezepotamya" });
            _dbContext.SaveChanges();
            IEnumerable<Client> response = _controller.Get();
            Assert.That(response.Count<Client>(), Is.GreaterThanOrEqualTo(1));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _controller.Dispose();
            _dbContext.Dispose();
        }
    }
}