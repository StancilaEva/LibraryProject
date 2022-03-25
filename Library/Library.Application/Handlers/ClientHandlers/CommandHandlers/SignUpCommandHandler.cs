using Library.Application.Commands.ClientCommands;
using Library.Core;
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

        public Task<Client> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            Client client = request.Client;
            if (isValid(client))
            {
                _clientRepository.InsertClient(client);
                return Task.FromResult(client);
               
            }
            else
            {
                throw new EmailAlreadyInUseException("this email is already being used by another user");
            }
        }

        private bool isValid(Client client)
        {
            if (checkiIfEmailIsAlreadyUsed(client.Email) == null)
            {
                return false;
            }
            return true;
        }

        private Client checkiIfEmailIsAlreadyUsed(string email)
        {

            return _clientRepository.GetClientByEmail(email);

        }
    }
}
