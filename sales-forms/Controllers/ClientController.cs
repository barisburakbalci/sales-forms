using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        public FormDbContext _dbContext;

        public ClientController(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _dbContext.Clients.Include("Forms").ToList();
        }

        [HttpGet("{id}")]
        public Client? Get(long id)
        {
            Client? client = _dbContext.Clients.SingleOrDefault(q => q.Id == id);

            return client;
        }

        [HttpPost]
        public Client Post([FromBody] CreateClientVM clientData)
        {
            Client client = (Client)clientData;
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            return client;
        }

        [HttpPut("{id}")]
        public Client? Put(long id, [FromBody] UpdateClientVM client)
        {
            Client? existingClient = _dbContext.Clients.SingleOrDefault(q => q.Id == id);
            
            if (existingClient != null)
            {
                _dbContext.Clients.Entry(existingClient).CurrentValues.SetValues(client);
                _dbContext.SaveChanges();
            }

            
            return existingClient;
        }

        [HttpDelete("{id}")]
        public Client? Delete(long id)
        {
            Client? existingClient = _dbContext.Clients.SingleOrDefault(q => q.Id == id);

            if (existingClient != null)
            {
                _dbContext.Clients.Remove(existingClient);
                _dbContext.SaveChanges();
            }

            return existingClient;
        }
    }
}

