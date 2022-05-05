using Library.Application.Commands.ClientCommands;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MainApp;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.CommandHandlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Client>
    {
        IClientRepository _clientRepository;

        public SignUpCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            Client client = new Client(request.Username,request.Password,
                new Address(request.Street,request.City,request.County,request.Number)
                ,request.Email);
            if (await IsValid(client))
            {
                await _clientRepository.InsertClientAsync(client);
                return client;
            }
            else
            {
                throw new EmailAlreadyInUseException("this email is already being used by another user");
            }
        }

        //as putea verifica si direct daca e null in loc sa 
        private async Task<bool> IsValid(Client client)
        {
            var clientByEmail = await CheckIfEmailIsAlreadyUsed(client.Email);
            if (clientByEmail != null)
            {
                return false;
            }
            return true;
        }

        private async Task<Client> CheckIfEmailIsAlreadyUsed(string email)
        {
            return await _clientRepository.GetClientByEmailAsync(email);
        }

    }
}
