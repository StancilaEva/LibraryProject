using Library.Application.Queries.ClientQueries;
using Library.Core;
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
        public Task<Client> Handle(GetClientLogInQuery request, CancellationToken cancellationToken)
        {
            List<Client> clientList = _clientRepository.GetAllClients();
            Client client = checkiIfEmailIsAlreadyUsed(request.Email);
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
                  return Task.FromResult(client);
        }

        private Client checkiIfEmailIsAlreadyUsed(string email)
        {

            return _clientRepository.GetClientByEmail(email);

        }

    }
}
