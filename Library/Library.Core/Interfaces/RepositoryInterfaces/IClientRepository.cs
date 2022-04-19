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

        public Task<Client> GetClientByEmailAndPassowrdAsync(String email, String password);

        public Task<Client> InsertClientAsync(Client client);

        public Task<Client> GetClientByEmailAsync(string email);

        public void UpdateClientAdressAsync(int id,Address address);

        public Task<Client> GetClientByIdAsync(int id);


    }
}
