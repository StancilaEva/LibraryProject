using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BookCommands
{
    internal class CreateBookCommand :IRequest<Book>
    {
        public Book NewBook { get; set; }
    }
}
