using Library.Application.Commands.FavoritesCommands;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.FavoritesHandlers.CommandHandler
{
    public class RemoveFavoriteCommandHandler : IRequestHandler<RemoveFavoriteCommand, bool>
    {
        private IFavoritesRepository _favoriteRepository;

        public RemoveFavoriteCommandHandler(IFavoritesRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<bool> Handle(RemoveFavoriteCommand request, CancellationToken cancellationToken)
        {
            var review = await _favoriteRepository.GetFavoriteByClientAndComic(request.UserId,request.ComicId);
            var result = await _favoriteRepository.DeleteFavorite(review);
            return result;
        }
    }
}
