using Library.Application.Commands.ClientCommands;
using Library.Application.DTOs;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
using MainApp;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.CommandHandlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, string>
    {
        IClientRepository _clientRepository;

        public SignUpCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<string> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            Client client = new Client(request.SignUpDTO.Username,request.SignUpDTO.Password,
                new Address(request.SignUpDTO.Street,request.SignUpDTO.City,request.SignUpDTO.County,request.SignUpDTO.Number)
                ,request.SignUpDTO.Email);
            if (isValid(client))
            {
                _clientRepository.InsertClientAsync(client);
                return Task.FromResult(client.Username);
            }
            else
            {
                throw new EmailAlreadyInUseException("this email is already being used by another user");
            }
        }

        private bool isValid(Client client)
        {
            if (checkIfEmailIsAlreadyUsed(client.Email) == null)
            {
                return false;
            }
            return true;
        }

        private async Task<Client> checkIfEmailIsAlreadyUsed(string email)
        {
            return await _clientRepository.GetClientByEmailAsync(email);
        }

    }
}
