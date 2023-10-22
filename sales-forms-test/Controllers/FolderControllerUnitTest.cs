using Microsoft.EntityFrameworkCore;
using sales_forms.Controllers;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

namespace sales_forms_test.Controllers
{
    public class FolderControllerTests
    {
        private readonly FolderController _controller;
        private readonly FormDbContext _dbContext;
        public FolderControllerTests() {
            var optionsBuilder = new DbContextOptionsBuilder<FormDbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            _dbContext = new(optionsBuilder.Options);
            _controller = new(_dbContext);
        }

        [Test]
        public void CreateFolder_Valid()
        {
            CreateFolderVM folder = new() { Name = "Tulpar Kauçuk" };
            Folder? createdFolder = _controller.Post(folder);

            Assert.That(createdFolder, Is.Not.Null);
            Assert.That(createdFolder.Name, Is.EqualTo(folder.Name));
        }

        [Test]
        public void UpdateFolder_Valid()
        {
            Folder lastFolder = new() { Name = "Aşkar Profil" };
            _dbContext.Folders.Add(lastFolder);
            _dbContext.SaveChanges();
            var response = _controller.Put(lastFolder.Id ,new UpdateFolderVM { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.InstanceOf<Folder>());
        }

        [Test]
        public void UpdateFolder_NotFound()
        {
            var response = _controller.Put(100, new UpdateFolderVM { Name = "Tulpar Kauçuk" });
            Assert.That(response, Is.Null);
        }

        [Test]
        public void DeleteFolder_Valid()
        {
            Folder lastFolder = new() { Name = "Gözpa Kauçuk" };
            _dbContext.Folders.Add(lastFolder);
            _dbContext.SaveChanges();
            var response = _controller.Delete(lastFolder.Id);
            Assert.That(response, Is.InstanceOf<Folder>());
        }

        [Test]
        public void DeleteFolder_NotFound()
        {
            var response = _controller.Delete(100);
            Assert.That(response, Is.Null);
        }

        [Test]
        public void GetFolders()
        {
            _dbContext.Folders.Add(new Folder{ Name = "Mezepotamya" });
            _dbContext.SaveChanges();
            IEnumerable<Folder> folders = _controller.Get();


            Assert.That(folders.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetFolder_Valid()
        {
            Folder lastFolder = new() { Name = "Standart Profil" };
            _dbContext.Folders.Add(lastFolder);
            _dbContext.SaveChanges();

            var folder = _controller.Get(lastFolder.Id);
            Assert.That(folder, Is.InstanceOf<Folder>());
        }

        [Test]
        public void GetFolder_NotFound()
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