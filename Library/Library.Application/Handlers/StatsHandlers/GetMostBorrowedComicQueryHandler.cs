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
    public class GetMostBorrowedComicQueryHandler : IRequestHandler<GetMostBorrowedComicQuery,Dictionary<ComicBook,int>>
    {
        ILendRepository _lendRepository;

        public GetMostBorrowedComicQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<Dictionary<ComicBook, int>> Handle(GetMostBorrowedComicQuery request, CancellationToken cancellationToken)
        {
            var result = await _lendRepository.MostBorrowedComicsInThePastMonthAsync();
            return result;
        }
    }
}
