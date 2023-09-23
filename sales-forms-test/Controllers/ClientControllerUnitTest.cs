using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class ClientControllerTests
    {
        private readonly ClientController _controller;
        private readonly FormDbContext _dbContext;
        public ClientControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new ClientController(_dbContext);
        }

        [Test]
        public void CreateClient_Valid()
        {
            var response = _controller.Post(new ClientCreateViewModel{ Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<CreatedResult>());
        }

        [Test]
        public void UpdateClient_Valid()
        {
            Client lastClient = new() { Name = "Aþkar Profil" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();
            var response = _controller.Put(lastClient.Id ,new ClientCreateViewModel { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void UpdateClient_NotFound()
        {
            var response = _controller.Put(100, new ClientCreateViewModel { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void DeleteClient_Valid()
        {
            Client lastClient = new() { Name = "Gözpa Kauçuk" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastClient.Id);
            Assert.That(response, Is.InstanceOf<OkResult>());
        }

        [Test]
        public void DeleteClient_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void GetClients()
        {
            _dbContext.Clients.Add(new Client{ Name = "Mezepotamya" });
            _dbContext.SaveChanges();
            IEnumerable<Client> response = _controller.Get();
            Assert.That(response.Count<Client>(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetClient_Valid()
        {
            Client lastClient = new() { Name = "Standart Profil" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();

            var response = _controller.Get(lastClient.Id);
            Assert.That(response, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetClient_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.InstanceOf<NotFoundResult>());
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _controller.Dispose();
            _dbContext.Dispose();
        }
    }
}