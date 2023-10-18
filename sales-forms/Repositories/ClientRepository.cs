using System;
using Microsoft.EntityFrameworkCore;
using sales_forms.Data;
using sales_forms.Exceptions;
using sales_forms.Models;

namespace sales_forms.Repositories
{
    public class ClientRepository
    {
        private readonly DbSet<Client> Clients;
        private readonly FormDbContext DbContext;
        private readonly ILogger Logger;

        public ClientRepository(FormDbContext dbContext, ILogger logger)
        {
            DbContext = dbContext;
            Clients = dbContext.Clients;
            Logger = logger;
        }

        private void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            } catch (Exception exception)
            {
                Logger.LogError("{message}", exception.Message);
            }
        }

        public IEnumerable<Client> GetClients()
        {
            return Clients.ToList();
        }

        public Client GetClient(long id)
        {
            return Clients.SingleOrDefault(client => client.Id == id)
                ?? throw new ModelNotFoundException(nameof(Client));
        }

        public Client CreateClient(Client client)
        {
            Clients.Add(client);
            SaveChanges();

            return client;
        }

        public Client UpdateClient(long id, IDictionary<string, object> keyValuePairs)
        {
            Client client = GetClient(id);

            Clients.Entry(client).CurrentValues.SetValues(keyValuePairs);
            SaveChanges();

            return client;
        }

        public Client DeleteClient(long id)
        {
            Client client = GetClient(id);

            Clients.Remove(client);
            SaveChanges();

            return client;
        }
    }
}

