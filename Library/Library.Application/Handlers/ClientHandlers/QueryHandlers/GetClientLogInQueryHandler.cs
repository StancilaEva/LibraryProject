using Library.Application.DTOs;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using Library.Infrastructure;
using MainApp;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.QueryHandlers
{
    public class GetClientLogInQueryHandler : IRequestHandler<GetClientLogInQuery, LogInDTO>
    {
        IClientRepository _clientRepository;

        public GetClientLogInQueryHandler()
        {
            _clientRepository = new ClientRepository();
        }

        public Task<LogInDTO> Handle(GetClientLogInQuery request, CancellationToken cancellationToken)
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
            {
                LogInDTO logInDTO = new LogInDTO(client.Username, client.Id);
                return Task.FromResult(logInDTO);
            }
        }

        private Client checkiIfEmailIsAlreadyUsed(string email)
        {

            return _clientRepository.GetClientByEmail(email);

        }

    }
}
