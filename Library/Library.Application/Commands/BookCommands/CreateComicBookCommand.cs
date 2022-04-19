
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands.CreateBookCommand
{
    public class CreateComicBookCommand : IRequest<ComicBook>
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int IssueNumber { get; set; }
        public string Cover { get; set; }
    }
}
