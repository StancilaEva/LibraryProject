using Library.Application.Commands.ReviewCommands;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ReviewHandlers.Commands
{
    internal class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Review>
    {
        private IReviewRepository _reviewsRepository;
        public AddReviewCommandHandler(IReviewRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        public async Task<Review> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            Review review = new Review(request.TextReview, request.Rating, request.ClientId, request.ComicId);
            return  await _reviewsRepository.WriteReviewAsync(review);
        }
    }
}
