using Library.Application.Commands.BookCommands;
using Library.Application.Commands.BookCommands.CreateBookCommand;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers.CommandHandlers
{
    public class DeleteComicBookCommandHandler : IRequestHandler<DeleteComicBookCommand,ComicBook>
    {
        IBookRepository _bookRepository;

        public DeleteComicBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ComicBook> Handle(DeleteComicBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.DeleteAsync(request.Id);
            return book;
        }
    }
}
