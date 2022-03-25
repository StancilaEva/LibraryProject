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
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = request.NewBook;
            _bookRepository.InsertBook(book);
            return Task.FromResult(book);
        }
    }
}
