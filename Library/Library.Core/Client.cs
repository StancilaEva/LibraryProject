using Library.Core.DesignPatterns.Observer;
using Library.Core.Exceptions;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Client 
    {
        public int Id { get; set; }
        //pentru identity
        public string IdentityId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public Address Address  { get; set; }


        public Client()
        {
        }

        public Client(int id, string username, Address address, string email)
        {
            Id = id;
            Username = username;
            Address = address;
            Email = email;
        }

        public Client(string identityId, string username, Address address, string email)
        {
            IdentityId = identityId;
            Username = username;
            Address = address;
            Email = email;
        }

        public Client (string username, Address address, string email)
        {
            if (!String.IsNullOrEmpty(username) && username.Length >= 4)
            {
                Username = username;
            }
            else
            {
                throw new InvalidUserCredentialsException("Invalid username");
            }
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if (!String.IsNullOrEmpty(email) && regex.IsMatch(email))
            {
                Email = email;
            }
            else
            {
                throw new InvalidUserCredentialsException("Invalid email");
            }
            Address = address;

        }
    }
}
