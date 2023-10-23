using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class AppUserControllerTests
    {
        private readonly AppUserController _controller;
        private readonly FormDbContext _dbContext;
        public AppUserControllerTests() {
            DbContextOptionsBuilder<FormDbContext> optionBuilder = new();
            optionBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateAppUser_Valid()
        {
            CreateAppUserVM appUser = new()
            {
                Name = "Test User",
                Email = "testuser@email.com",
                Password = "123"
            };

            AppUser? createdAppUser = _controller.Post(appUser);

            Assert.That(createdAppUser, Is.Not.Null);
            Assert.That(createdAppUser.Name, Is.EqualTo(appUser.Name));
        }

        [Test]
        public void UpdateAppUser_Valid()
        {
            AppUser appUser = new()
            {
                Name = "Test User",
                Email = "testuser@email.com",
                PasswordHash = "123"
            };

            _dbContext.AppUsers.Add(appUser);
            _dbContext.SaveChanges();

            UpdateAppUserVM updatedAppUser = new()
            {
                Name = "Updated Test User",
            };


            var response = _controller.Put(appUser.Id, updatedAppUser);
            Assert.That(response, Is.InstanceOf<AppUser>());
        }

        [Test]
        public void UpdateAppUser_NotFound()
        {
            UpdateAppUserVM appUser = new();

            var response = _controller.Put(100, appUser);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteAppUser_Valid()
        {
            AppUser lastAppUser = GetDummyAppUser();

            _dbContext.AppUsers.Add(lastAppUser);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastAppUser.Id);
            Assert.That(response, Is.InstanceOf<AppUser>());
        }

        [Test]
        public void DeleteAppUser_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetAppUsers()
        {
            AppUser appUser = GetDummyAppUser();

            _dbContext.AppUsers.Add(appUser);
            _dbContext.SaveChanges();
            IEnumerable<AppUser> appUsers = _controller.Get();


            Assert.That(appUsers.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetAppUser_Valid()
        {
            AppUser appUser = GetDummyAppUser();
            _dbContext.AppUsers.Add(appUser);
            _dbContext.SaveChanges();

            var response = _controller.Get(appUser.Id);
            Assert.That(response, Is.InstanceOf<AppUser>());
        }

        [Test]
        public void GetAppUser_NotFound()
        {
            var response = _controller.Get(100);
            Assert.That(response, Is.Null);
        }

        private AppUser GetDummyAppUser()
        {
            AppUser appUser = new()
            {
                Name = "Dummy Test User",
                Email = "dummytestuser@email.com",
                PasswordHash = "123"
            };

            return appUser;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Dispose();
        }
    }
}