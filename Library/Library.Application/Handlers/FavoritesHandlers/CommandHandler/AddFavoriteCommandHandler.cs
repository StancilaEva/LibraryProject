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
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, Favorite>
    {
        private IFavoritesRepository _favoriteRepository;

        public AddFavoriteCommandHandler(IFavoritesRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<Favorite> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            return await _favoriteRepository.AddFavoritesAsync(request.ClientId, request.ComicId);
        }
    }
}
