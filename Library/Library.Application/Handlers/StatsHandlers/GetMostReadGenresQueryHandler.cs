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
    public class GetMostReadGenresQueryHandler : IRequestHandler<GetMostReadGenresQuery, Dictionary<Genre, int>>
    {
        ILendRepository _lendRepository;

        public GetMostReadGenresQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }
        public async Task<Dictionary<Genre,int>> Handle(GetMostReadGenresQuery request, CancellationToken cancellationToken)
        {
            return await _lendRepository.MostReadGenresAsync();
        }
    }
}
