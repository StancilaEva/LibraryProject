using Library.Core.DesignPatterns.Observer;
using Library.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Client 
    {
        public int Id { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }

        [JsonIgnore]
        public Address Address  { get; set; }
        public string Email { get; set; }


        public Client()
        {
        }

        public Client(int id, string username, string password, Address address, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Address = address;
            Email = email;

        }
        public Client (string username, string password, Address address, string email)
        {
            if (!String.IsNullOrEmpty(username) && username.Length >= 4)
            {
                Username = username;
            }
            else
            {
                throw new InvalidUsernameException("Invalid username");
            }

            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if(!String.IsNullOrEmpty(email) && regex.IsMatch(email))
            {
                Email = email;
            }
            else
            {
                throw new InvalidEmailException("Invalid email");
            }

            if(!String.IsNullOrEmpty(password) && password.Length>=4)
            {
                Password = password;
            }
            else
            {
                throw new InvalidPasswordException("Password must be at least 4 characters long");
            }

            Address = address;

        }
        public override string ToString()
        {
            return $"{Username}";
        }

       
    }
}
