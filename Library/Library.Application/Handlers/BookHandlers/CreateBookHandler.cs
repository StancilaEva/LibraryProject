using Library.Application.Commands.BookCommands;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers
{
    internal class CreateBookHandler : IRequestHandler<CreateBookCommand, Book>
    {
        IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            _bookRepository.InsertBook(request.NewBook);
            return Task.FromResult(request.NewBook);
        }
    }
}
