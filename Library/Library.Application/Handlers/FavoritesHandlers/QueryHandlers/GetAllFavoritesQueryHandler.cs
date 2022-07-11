using Library.Application.Paging;
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
    public class GetAllFavoritesQueryHandler : IRequestHandler<GetAllFavoritesQuery, FavoritePage>
    {
        private IFavoritesRepository _favRepository;

        public GetAllFavoritesQueryHandler(IFavoritesRepository favRepository)
        {
            _favRepository = favRepository;
        }

        public async Task<FavoritePage> Handle(GetAllFavoritesQuery request, CancellationToken cancellationToken)
        {
            var result = await _favRepository.GetAllFavoritesAsync(request.ClientId,request.Page);
            var pageNumber = await _favRepository.GetAllFavoritesPageCountAsync(request.ClientId, request.Page);
            return new FavoritePage()
            {
                PageCount = pageNumber,
                Comics = result
            };
        }
    }
}
