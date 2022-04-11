using Library.Application.DTOs;
using Library.Application.Queries.ClientQueries;
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

namespace Library.Application.Handlers.ClientHandlers.QueryHandlers
{
    public class GetClientLogInQueryHandler : IRequestHandler<GetClientLogInQuery, LogInDTO>
    {
        IClientRepository _clientRepository;

        public GetClientLogInQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<LogInDTO> Handle(GetClientLogInQuery request, CancellationToken cancellationToken)
        {
            List<Client> clientList = await _clientRepository.GetAllClientsAsync();
            Client client = await checkiIfEmailIsAlreadyUsed(request.Email);
            
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

                return logInDTO;
            }
        }

        private async Task<Client> checkiIfEmailIsAlreadyUsed(string email)
        {

            return await  _clientRepository.GetClientByEmailAsync(email);
        }

    }
}
