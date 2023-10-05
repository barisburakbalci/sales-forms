using Microsoft.AspNetCore.Mvc;
using sales_forms.Data;
using sales_forms.Models;

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
            return _dbContext.Clients.ToList();
        }

        [HttpGet("{id}")]
        public Client? Get(int id)
        {
            Client? client = _dbContext.Clients.SingleOrDefault(q => q.Id == id);

            return client;
        }

        [HttpPost]
        public Client Post([FromBody] Client clientData)
        {
            Client client = new() { Name = clientData.Name };

            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            return client;
        }

        [HttpPut("{id}")]
        public Client? Put(int id, [FromBody] Client client)
        {
            Client? existingClient = _dbContext.Clients.SingleOrDefault(q => q.Id == id);
            
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                _dbContext.SaveChanges();
            }

            
            return existingClient;
        }

        [HttpDelete("{id}")]
        public Client? Delete(int id)
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

