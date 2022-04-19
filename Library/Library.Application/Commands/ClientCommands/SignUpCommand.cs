
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.ClientCommands
{
    public class SignUpCommand : IRequest<Client>
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
