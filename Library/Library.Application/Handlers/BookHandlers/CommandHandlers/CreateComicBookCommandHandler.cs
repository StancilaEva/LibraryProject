using Library.Application.Commands.BookCommands;
using Library.Application.Commands.BookCommands.CreateBookCommand;
using Library.Application.utils;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.AzureBlobStorage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers
{
    public class CreateComicBookCommandHandler : IRequestHandler<CreateComicBookCommand, ComicBook>
    {
        IBookRepository _bookRepository;

        public CreateComicBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ComicBook> Handle(CreateComicBookCommand request, CancellationToken cancellationToken)
        {
            var book = new ComicBook(request.Title, request.Publisher, GenreConverter.FromString(request.Genre), request.IssueNumber,request.Cover);
            var result = await _bookRepository.InsertBookAsync(book);
            return result;

        }
    }
}
