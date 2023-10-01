using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Models;
using sales_forms.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sales_forms.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
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
        public Client? Post([FromBody] ClientCreateViewModel clientVM)
        {
            Client client = new() { Name = clientVM.Name };
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            return client;
        }

        [HttpPut("{id}")]
        public Client? Put(int id, [FromBody] ClientCreateViewModel client)
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
            var existingClient = _dbContext.Clients.SingleOrDefault<Client>(q => q.Id == id);

            if (existingClient != null)
            {
                _dbContext.Clients.Remove(existingClient);
                _dbContext.SaveChanges();
            }

            return existingClient;
        }
    }
}

