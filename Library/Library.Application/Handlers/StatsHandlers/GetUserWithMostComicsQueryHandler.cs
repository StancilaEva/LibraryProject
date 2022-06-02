using Library.Application.Exceptions;
using Library.Application.Queries.StatsQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.StatsHandlers
{
    internal class GetUserWithMostComicsQueryHandler : IRequestHandler<GetUserWithMostComicsQuery, Dictionary<Client, int>>
    {
        ILendRepository _lendRepository;
        IClientRepository _clientRepository;
        public GetUserWithMostComicsQueryHandler(ILendRepository lendRepository, IClientRepository clientRepository)
        {
            _lendRepository = lendRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Dictionary<Client, int>> Handle(GetUserWithMostComicsQuery request, CancellationToken cancellationToken)
        {
            var clientId = await _lendRepository.UserIdWithMostLendsAsync();
            var client = await _clientRepository.GetClientByIdAsync(clientId);
            if (client != null)
            {
                var noOfLends = await _lendRepository.UserCountWithMostLendsAsync();
                Dictionary<Client, int> clientAndNoOfLends = new Dictionary<Client, int>();
                clientAndNoOfLends.Add(client, noOfLends);
                return clientAndNoOfLends;
            }
            else
            {
                throw new NoLendsException("No user lends registered yet");
            }

        }
    }
}
