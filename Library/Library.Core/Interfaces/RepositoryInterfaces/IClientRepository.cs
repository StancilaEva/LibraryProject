using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.RepositoryInterfaces
{
    public interface IClientRepository
    {
        public Task<List<Client>> GetAllClientsAsync();

        public Task<Client> InsertClientAsync(Client client);

        public Task<Client> GetClientByEmailAsync(string email);

        public Task<Address> UpdateClientAdressAsync(int id, Address newAddress);

        public Task<Client> GetClientByIdAsync(int id);

        public Task<Address> GetClientAddress(int id);
        public Task<List<Lend>> GetAllClientLends(int id);

        public Task<Client> GetUserByIdentityId(string identityId);
    }
}
