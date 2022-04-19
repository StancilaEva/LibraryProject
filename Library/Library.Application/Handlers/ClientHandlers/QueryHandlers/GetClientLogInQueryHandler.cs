using Library.Application.Queries.ClientQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MainApp;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.QueryHandlers
{
    public class GetClientLogInQueryHandler : IRequestHandler<GetClientLogInQuery, Client>
    {
        IClientRepository _clientRepository;

        public GetClientLogInQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> Handle(GetClientLogInQuery request, CancellationToken cancellationToken)
        {
            var client = await CheckIfEmailIsAlreadyUsed(request.Email);
            if (client == null)
            {
                throw new NonExistentUserException("this email is not in the database");
            }
            else
            if (!client.Password.Equals(request.Password))
            {
                throw new WrongPasswordException("wrong password");
            }
            else
            {
                return client;
            }
        }

        private async Task<Client> CheckIfEmailIsAlreadyUsed(string email)
        {
            return await _clientRepository.GetClientByEmailAsync(email);
        }

    }
}
