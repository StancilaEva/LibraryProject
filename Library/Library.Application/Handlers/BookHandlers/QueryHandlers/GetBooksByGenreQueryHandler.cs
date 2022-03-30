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
    public class GetBooksByGenreQueryHandler : IRequestHandler<GetBooksByGenreQuery, List<Book>>
    {
        IBookRepository _bookRepository;

        public GetBooksByGenreQueryHandler()
        {
            _bookRepository = new BookRepository();
        }

        public Task<List<Book>> Handle(GetBooksByGenreQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByGenre(request.Genre);
            return Task.FromResult(books);
        }
    }
}
