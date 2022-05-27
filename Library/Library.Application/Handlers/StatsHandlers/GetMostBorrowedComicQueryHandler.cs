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
        IBookRepository _bookRepository;

        public GetMostBorrowedComicQueryHandler(ILendRepository lendRepository, IBookRepository bookRepository)
        {
            _lendRepository = lendRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Dictionary<ComicBook, int>> Handle(GetMostBorrowedComicQuery request, CancellationToken cancellationToken)
        {
            var result = await _lendRepository.MostBorrowedComicsInThePastMonthAsync();
            Dictionary<ComicBook, int> comicsAndNoOfLends = new Dictionary<ComicBook, int>();
            foreach (var item in result.Keys)
            {
                ComicBook comic = await _bookRepository.GetBookByIdAsync(item);
                comicsAndNoOfLends.Add(comic, result[item]);
            }
            return comicsAndNoOfLends;
        }
    }
}
