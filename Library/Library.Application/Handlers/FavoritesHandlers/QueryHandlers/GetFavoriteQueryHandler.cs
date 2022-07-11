using Library.Application.Queries.FavoriteQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.FavoritesHandlers.QueryHandlers
{
    public class GetFavoriteQueryHandler : IRequestHandler<GetFavoriteQuery, Favorite>
    {
        private IFavoritesRepository _favoriteRepository;

        public GetFavoriteQueryHandler(IFavoritesRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        public async Task<Favorite> Handle(GetFavoriteQuery request, CancellationToken cancellationToken)
        {
            return await _favoriteRepository.GetFavoriteByClientAndComic(request.ClientId, request.ComicId);
        }
    }
}
