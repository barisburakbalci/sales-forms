using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;

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
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateClient_Valid()
        {
            var client = new Client { Name = "Tulpar Kauçuk" };
            Client? createdClient = _controller.Post(client);

            Assert.That(createdClient, Is.Not.Null);
            Assert.That(createdClient.Name, Is.EqualTo(client.Name));
        }

        [Test]
        public void UpdateClient_Valid()
        {
            Client lastClient = new() { Name = "Aşkar Profil" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();
            var response = _controller.Put(lastClient.Id ,new Client { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<Client>());
        }

        [Test]
        public void UpdateClient_NotFound()
        {
            var response = _controller.Put(100, new Client { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteClient_Valid()
        {
            Client lastClient = new() { Name = "Gözpa Kauçuk" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastClient.Id);
            Assert.That(response, Is.InstanceOf<Client>());
        }

        [Test]
        public void DeleteClient_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetClients()
        {
            _dbContext.Clients.Add(new Client{ Name = "Mezepotamya" });
            _dbContext.SaveChanges();
            IEnumerable<Client> clients = _controller.Get();


            Assert.That(clients.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetClient_Valid()
        {
            Client lastClient = new() { Name = "Standart Profil" };
            _dbContext.Clients.Add(lastClient);
            _dbContext.SaveChanges();

            var client = _controller.Get(lastClient.Id);
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        public void GetClient_NotFound()
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