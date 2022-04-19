using Library.Application;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private LibraryContext context;

        public ClientRepository(LibraryContext context)
        {
            this.context = context;
        }

        public async Task<Client> GetClientByIdAsync(string id)
        {
            return  await context.Clients.Include(client=>client.Address).FirstOrDefaultAsync((client) => client.Id.Equals(id));
            
        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            return await context.Clients.Include(client=> client.Address).FirstOrDefaultAsync((client) => client.Email.Equals(email));
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await context.Clients.ToListAsync();
        }
        
        public async Task<Client> InsertClientAsync(Client client)
        {
            context.Clients.Add(client);
            await context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetClientByEmailAndPassowrdAsync(String email,String password)
        {
            Client client = await context.Clients.Include(client=>client.Address)
                .FirstOrDefaultAsync((client) => client.Email.Equals(email) && client.Password.Equals(password));
            if(client == null)
            {
                throw new InvalidOperationException("Wrong email or password");
            }

            return client;
        }

        public void UpdateClientAdressAsync(int id, Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await context.Clients.Include(client=>client.Address)
                .FirstOrDefaultAsync((client) => client.Id == id);
        }
    }
}
