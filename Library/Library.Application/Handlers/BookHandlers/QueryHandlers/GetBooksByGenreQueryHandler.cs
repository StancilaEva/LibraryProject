using Library.Application.DTOs;
using Library.Application.Queries.BookQueries;
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
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, List<BooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetBooksByGenreQueryHandler()
        {
            _bookRepository = new BookRepository();
        }

        public Task<List<BooksDTO>> Handle(GetBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByGenre(request.Genre)
                .Select(book => new BooksDTO(book.Id, book.Title, book.Author)).ToList();
            return Task.FromResult(books);
        }
    }
}
