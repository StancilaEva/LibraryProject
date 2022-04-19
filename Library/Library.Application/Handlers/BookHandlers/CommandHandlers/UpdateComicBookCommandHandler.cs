using Library.Application.Commands.BookCommands;
using Library.Application.utils;
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
    public class UpdateComicBookCommandHandler : IRequestHandler<UpdateComicBookCommand, ComicBook>
    {
        IBookRepository _bookRepository;

        public UpdateComicBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ComicBook> Handle(UpdateComicBookCommand request, CancellationToken cancellationToken)
        {
            var newComicBook = await _bookRepository.UpdateAsync(new ComicBook(request.ComicBook.Id, request.ComicBook.Title, request.ComicBook.Publisher,
                request.ComicBook.Genre, request.ComicBook.IssueNumber, request.ComicBook.Cover));
            return newComicBook;
        }
    }
}
