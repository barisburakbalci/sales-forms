using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class FolderController : GenericControllerBase<Folder, CreateFolderVM, UpdateFolderVM>
    {
        public FolderController(FormDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        [HttpGet("{id}/with-forms")]
        public Folder? Get(long id)
        {
            Folder? folder = _dbContext.Folders.Include("Forms").SingleOrDefault(q => q.Id == id);

            return folder;
        }
    }
}

