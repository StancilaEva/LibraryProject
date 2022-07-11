using Library.Application.Queries.ReviewQueries;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ReviewHandlers.Queries
{
    public class GetComicBookRatingQueryHandler : IRequestHandler<GetComicBookRatingQuery, double>
    {
        IReviewRepository _reviewRepository;

        public GetComicBookRatingQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<double> Handle(GetComicBookRatingQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetComicBookRatingAsync(request.ComicId);
        }
    }
}
