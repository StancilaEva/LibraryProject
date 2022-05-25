using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IRegisterRepository
    {
        public Task<Client> InsertUserInTheDatabase(string email, string username, string password, Address address);
    }
}
