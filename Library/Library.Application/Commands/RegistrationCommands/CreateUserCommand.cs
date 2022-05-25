//Pentru identity

using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.RegistrationCommands
{
    public class CreateUserCommand : IRequest<string>
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
