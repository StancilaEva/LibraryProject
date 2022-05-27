using Library.Application.Queries.StatsQueries;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.StatsHandlers
{
    public class GetMostReadPublishersQueryHandler : IRequestHandler<GetMostReadPublishersQuery, Dictionary<string, int>>
    {
        ILendRepository _lendRepository;

        public GetMostReadPublishersQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<Dictionary<string, int>> Handle(GetMostReadPublishersQuery request, CancellationToken cancellationToken)
        {
            return await _lendRepository.MostReadPublishersAsync();
        }
    }
}
