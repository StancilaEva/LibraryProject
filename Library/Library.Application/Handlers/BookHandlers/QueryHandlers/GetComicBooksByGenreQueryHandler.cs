using Library.Application.DTOs;
using Library.Application.Queries.BookQueries;
using Library.Application.utils;
using Library.Core;
using Library.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers.QueryHandlers
{
    public class GetComicBooksByGenreQueryHandler : IRequestHandler<GetComicBooksByGenreQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByGenreQueryHandler()
        {
            _bookRepository = new ComicBookRepository();
        }

        public Task<List<ComicBooksDTO>> Handle(GetComicBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByGenre(GenreConverter.FromString(request.Genre))
                .Select(book => new ComicBooksDTO(book.Id, book.Title, book.Publisher)).ToList();
            return Task.FromResult(books);
        }
    }
}
