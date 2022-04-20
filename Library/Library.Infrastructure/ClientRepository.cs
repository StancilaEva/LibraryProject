using Library.Application;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<Address> GetClientAddress(int id)
        {
            return await context.Addresses.Include(add => add.Client).FirstOrDefaultAsync(address=>address.Client.Id.Equals(id));

        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            return await context.Clients.Include(client=> client.Address).SingleOrDefaultAsync((client) => client.Email.Equals(email));
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
            Client client = await context.Clients
                .Include(client=>client.Address)
                .SingleOrDefaultAsync((client) => client.Email.Equals(email) && client.Password.Equals(password));
            

            return client;
        }

        public async Task<Address> UpdateClientAdressAsync(int id, Address newAddress)
        {
            var client = await context.Clients.Include(c=>c.Address).SingleOrDefaultAsync(c=>c.Id.Equals(id));
            if(client != null)
            {
                client.Address.City = newAddress.City;
                client.Address.Street = newAddress.Street;
                client.Address.Number = newAddress.Number;
                client.Address.County = newAddress.County;
                await context.SaveChangesAsync();
                return client.Address;
            }
            return null;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await context.Clients
                .Include(client=>client.Address)
                .FirstOrDefaultAsync((client) => client.Id == id);
        }

        public async Task<List<Lend>> GetAllClientLends(int id)
        {
            return await context.Lends.Include(lend => lend.Client)
                .Include(lend => lend.Book)
                .Where(lend => lend.Client.Id.Equals(id))
                .OrderByDescending(lend=>lend.StartDate)
                .ToListAsync();
        }

    }
}
