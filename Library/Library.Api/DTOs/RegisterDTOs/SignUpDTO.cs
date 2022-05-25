using System.ComponentModel.DataAnnotations;

namespace Library.Api.DTOs
{
    public class SignUpDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public int Number { get; set; }

    }
}
