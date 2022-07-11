using Library.Application.Queries.ReviewQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ReviewHandlers.Queries
{
    public class GetComicBookReviewsQueryHandler : IRequestHandler<GetComicReviewsQuery, List<Review>>
    {
        IReviewRepository _reviewRepository;

        public GetComicBookReviewsQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> Handle(GetComicReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _reviewRepository.GetAllComicReviewsAsync(request.ComicId);
        }
    }
}
