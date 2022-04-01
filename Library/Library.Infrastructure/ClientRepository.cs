using Library.Application;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        List<Client> clientList;
        public ClientRepository()
        {
            clientList = new List<Client>()
            {
                new Client("1","client1","12345678",new Address("Blvd Iuliu Maniu","Bucuresti","Bucuresti",12),"stancilaeva@gmail.com"),
                new Client("2","client2","asdfghjkl",new Address("Mihail Moxa","Bucuresti","Bucuresti",11),"stancilaeva@gmail.com"),
                new Client("3","client3","aefhkeghg",new Address("Bld Vladimirescu","Ploiesti","Prahova",15),"stancilaeva@gmail.com")
            };
        }
        public Client GetClientById(string id)
        {
            return clientList.Where((client) => client.Id.Equals(id)).FirstOrDefault();
        }
        public Client GetClientByEmail(string email)
        {
            return clientList.Where((client) => client.Email.Equals(email)).FirstOrDefault();
        }
        public List<Client> GetAllClients()
        {
            return clientList;
        }
        
        public void InsertClient(Client client)
        {
            clientList.Add(client);
        }

        public Client GetClientByEmailAndPassowrd()
        {
            throw new NotImplementedException();
        }
    }
}
