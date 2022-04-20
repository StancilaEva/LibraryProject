using Library.Application.Commands.ClientCommands;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.CommandHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand,Address>
    {
        IClientRepository _clientRepository;

        public UpdateAddressCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Address> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return await _clientRepository.UpdateClientAdressAsync(request.Id, request.NewAddress);
        }
    }
}
