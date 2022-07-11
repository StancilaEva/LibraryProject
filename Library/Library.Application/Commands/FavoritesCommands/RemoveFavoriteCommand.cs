using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.FavoritesCommands
{
    public class RemoveFavoriteCommand : IRequest<bool>
    {
        public int ComicId { get; set; }
        public int UserId { get; set; }
    }
}
