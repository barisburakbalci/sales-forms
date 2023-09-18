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
            return _dbContext.Clients.ToList<Client>();
        }

        [HttpGet("{id}")]
        public Client? Get(int id)
        {
            return _dbContext.Clients.FirstOrDefault<Client>(q => q.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientCreateViewModel clientData)
        {
            if (ModelState.IsValid)
            {
                // TODO: Convert ID to autoincrement index
                var client = new Client() { Name= clientData.Name, Id =1 };
                _dbContext.Clients.Add(client);
                _dbContext.SaveChanges();
                return Created("/Client/" + client.Id.ToString(), client);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Client client)
        {
            var existingClient = _dbContext.Clients.Single<Client>(q => q.Id == id);
            if (ModelState.IsValid)
            {
                _dbContext.Entry(existingClient).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingClient = _dbContext.Clients.Single<Client>(q => q.Id == id);
            _dbContext.Clients.Remove(existingClient);
            _dbContext.SaveChanges();
        }
    }
}

