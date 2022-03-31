using Library.Core.DesignPatterns.Observer;
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

        public Client(string id, string username, string password, Address address, string email)
        {
            this.username = username;
            this.password = password;
            this.address = address;
            this.Id = id;
            Email = email;

        }
        public Client (string username, string password, Address address, string email)
        {
            this.username = username;
            this.password = password;
            this.address = address;
            Email = email;

        }

        public Client()
        {
        }

        public string Username { get { return username; } set { if (value.Length >= 3) username = value; } }
        public string Password { get { return password; } set { if (value.Length >= 6) password = value; } }
        public Address Address { get { return address; } set { address = value; } }
        public string Id { get; set; }
        
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{username}";
        }

       
    }
}
