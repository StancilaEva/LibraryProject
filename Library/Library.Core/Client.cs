using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Client
    {
        private string username;
        private string password;
        private Address address;

        public Client(string username, string password, Address address)
        {
            this.username = username;
            this.password = password;
            this.address = address;
        }

        public Client()
        {
        }

        public string Username { get { return username; } set { if(value.Length>=3)username = value; } }
        public string Password { get { return password; } set { if(value.Length>=6)password = value; } }
        private Address Address { get { return address; } set { address = value; } }
    }
}
