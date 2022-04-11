using Library.Application.DTOs;
using Library.Application.Queries.BookQueries;
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

namespace Library.Application.Handlers.BookHandlers.QueryHandlers
{
    public class GetComicBooksByGenreQueryHandler : IRequestHandler<GetComicBooksByGenreQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByGenreQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBooksDTO>> Handle(GetComicBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.FilterBooksByGenreAsync(GenreConverter.FromString(request.Genre));
            var result = books.Select(book => new ComicBooksDTO(book.Id, book.Title, book.Publisher,book.Cover)).ToList();
            return result;
        }
    }
}
