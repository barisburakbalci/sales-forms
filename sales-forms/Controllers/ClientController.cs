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
        public IActionResult Get(int id)
        {
            Client? client = _dbContext.Clients.SingleOrDefault(q => q.Id == id);

            if (client == null)
            {
                return NotFound("Client not found!");
            }

            return Ok(client);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientCreateViewModel clientVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var client = new Client { Name = clientVM.Name };
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();

            return Created("/client/" + client.Id.ToString(), client);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientCreateViewModel client)
        {
            Client? existingClient = _dbContext.Clients.SingleOrDefault(q => q.Id == id);
            
            if (existingClient == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            existingClient.Name = client.Name;
            _dbContext.SaveChanges();

            return Ok(existingClient);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingClient = _dbContext.Clients.SingleOrDefault<Client>(q => q.Id == id);

            if (existingClient == null)
            {
                return NotFound();
            }

            _dbContext.Clients.Remove(existingClient);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}

