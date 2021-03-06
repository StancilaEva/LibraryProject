using Library.Application.Paging;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.FavoriteQueries
{
    public class GetAllFavoritesQuery : IRequest<FavoritePage>
    {
        public int Page { get; set; }
        public int ClientId { get; set; }
    }
}
