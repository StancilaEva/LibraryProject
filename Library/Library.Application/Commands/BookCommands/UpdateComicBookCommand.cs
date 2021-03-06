using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands
{
    public class UpdateComicBookCommand : IRequest<ComicBook>
    {
        public ComicBook ComicBook { get; set; }
    }
}
