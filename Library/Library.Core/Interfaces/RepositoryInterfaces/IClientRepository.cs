using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IClientRepository
    {
        public List<Client> GetAllClients();
        public Client GetClientByEmailAndPassowrd();
        public void InsertClient(Client client);
    }
}
