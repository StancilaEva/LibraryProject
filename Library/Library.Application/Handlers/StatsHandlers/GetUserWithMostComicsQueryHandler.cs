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
    internal class GetUserWithMostComicsQueryHandler : IRequestHandler<GetUserWithMostComicsQuery, (Client, int)>
    {
        ILendRepository _lendRepository;
        IClientRepository _clientRepository;
        public GetUserWithMostComicsQueryHandler(ILendRepository lendRepository, IClientRepository clientRepository)
        {
            _lendRepository = lendRepository;
            _clientRepository = clientRepository;
        }
        public async Task<(Client, int)> Handle(GetUserWithMostComicsQuery request, CancellationToken cancellationToken)
        {
            var clientId = await _lendRepository.UserIdWithMostLendsAsync();
            var client = await _clientRepository.GetClientByIdAsync(clientId);
            if (client != null)
            {
                var noOfLends = await _lendRepository.UserCountWithMostLendsAsync();
                return (client, noOfLends);
            }
            else
            {
                throw new NoLendsException("No Lends This Month");
            }

        }
    }
}
