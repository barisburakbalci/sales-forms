using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class FolderController : ControllerBase
    {
        public FormDbContext _dbContext;

        public FolderController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Folder> Get()
        {
            return _dbContext.Folders.Include("Forms").ToList();
        }

        [HttpGet("{id}")]
        public Folder? Get(long id)
        {
            Folder? folder = _dbContext.Folders.SingleOrDefault(q => q.Id == id);

            return folder;
        }

        [HttpPost]
        public Folder Post([FromBody] CreateFolderVM folderData)
        {
            Folder folder = (Folder)folderData;
            _dbContext.Folders.Add(folder);
            _dbContext.SaveChanges();

            return folder;
        }

        [HttpPut("{id}")]
        public Folder? Put(long id, [FromBody] UpdateFolderVM folder)
        {
            Folder? existingFolder = _dbContext.Folders.SingleOrDefault(q => q.Id == id);
            
            if (existingFolder != null)
            {
                _dbContext.Folders.Entry(existingFolder).CurrentValues.SetValues(folder.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingFolder;
        }

        [HttpDelete("{id}")]
        public Folder? Delete(long id)
        {
            Folder? existingFolder = _dbContext.Folders.SingleOrDefault(q => q.Id == id);

            if (existingFolder != null)
            {
                _dbContext.Folders.Remove(existingFolder);
                _dbContext.SaveChanges();
            }

            return existingFolder;
        }
    }
}

