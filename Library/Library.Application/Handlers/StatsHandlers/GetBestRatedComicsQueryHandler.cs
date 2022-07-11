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
    public class GetBestRatedComicsQueryHandler : IRequestHandler<GetBestRatedComicsQuery, Dictionary<ComicBook, double>>
    {
        private IReviewRepository _reviewRepository;
        private IBookRepository _bookRepository;

        public GetBestRatedComicsQueryHandler(IReviewRepository reviewRepository, IBookRepository bookRepository)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Dictionary<ComicBook, double>> Handle(GetBestRatedComicsQuery request, CancellationToken cancellationToken)
        {
            var comicResult = await _reviewRepository.BestRatedComicsAsync();
            Dictionary<ComicBook, double> comicsAndRating = new Dictionary<ComicBook, double>();
            foreach (var item in comicResult.Keys)
            {
                ComicBook comic = await _bookRepository.GetBookByIdAsync(item);
                comicsAndRating.Add(comic, comicResult[item]);
            }
            return comicsAndRating;
        }
    }
}
