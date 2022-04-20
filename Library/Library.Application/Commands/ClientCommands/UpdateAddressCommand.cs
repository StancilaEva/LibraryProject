using Library.Core;
using MediatR;

namespace Library.Application.Commands.ClientCommands
{
    public class UpdateAddressCommand : IRequest<Address>
    {
         public int Id { get; set; }
         public Address NewAddress { get; set; }

    }
}
