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
                new Client("1","client1","12345678",new Address("Blvd Iuliu Maniu","Bucuresti","Bucuresti",12),"client1@gmail.com"),
                new Client("2","client2","asdfghjkl",new Address("Mihail Moxa","Bucuresti","Bucuresti",11),"client2@gmail.com"),
                new Client("3","client3","aefhkeghg",new Address("Bld Vladimirescu","Ploiesti","Prahova",15),"client3@gmail.com")
            };
        }
        public List<Client> GetAllClients()
        {
            return clientList;
        }
        public Client GetClientByEmailAndPassowrd()
        {
            return null;
        }
        public void InsertClient(Client client)
        {
            clientList.Add(client);
        }
    }
}
