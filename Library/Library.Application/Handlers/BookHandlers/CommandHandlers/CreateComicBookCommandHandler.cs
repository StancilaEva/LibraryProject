using Library.Application.Commands.BookCommands;
using Library.Application.Commands.BookCommands.CreateBookCommand;
using Library.Application.DTOs;
using Library.Application.utils;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
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
        
        public Task<ComicBook> Handle(CreateComicBookCommand request, CancellationToken cancellationToken)
        {
            var book = new ComicBook(request.BookDTO.Title, request.BookDTO.Author, GenreConverter.FromString(request.BookDTO.Genre), request.BookDTO.IssueNumber,request.BookDTO.Cover);
            _bookRepository.InsertBookAsync(book);

            return Task.FromResult(book);

        }
    }
}
