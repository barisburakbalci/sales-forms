
using Microsoft.AspNetCore.Mvc;
using sales_forms.Models;
using sales_forms.Data;
using sales_forms.ViewModels;

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        public FormDbContext _dbContext;

        public AppUserController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<AppUser> Get()
        {
            return _dbContext.AppUsers.ToList();
        }

        [HttpGet("{id}")]
        public AppUser? Get(long id)
        {
            return _dbContext.AppUsers.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public AppUser? Post([FromBody] CreateAppUserVM userData)
        {
            AppUser user = (AppUser)userData;
            _dbContext.AppUsers.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        [HttpPut("{id}")]
        public AppUser? Put(long id, [FromBody] UpdateAppUserVM user)
        {
            var existingUser = _dbContext.AppUsers.SingleOrDefault(q => q.Id == id);

            if (existingUser != null)
            {
                _dbContext.AppUsers.Entry(existingUser).CurrentValues.SetValues(user.AsDictionary());
                _dbContext.SaveChanges();
            }

            return existingUser;
        }

        [HttpDelete("{id}")]
        public AppUser? Delete(long id)
        {
            var existingUser = _dbContext.AppUsers.SingleOrDefault(q => q.Id == id);

            if (existingUser != null)
            {
                _dbContext.AppUsers.Remove(existingUser);
                _dbContext.SaveChanges();
            }

            return existingUser;
        }
    }
}
