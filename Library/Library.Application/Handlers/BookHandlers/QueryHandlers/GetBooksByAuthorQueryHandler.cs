using Library.Application.Queries.BookQueries;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers
{
    public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, List<Book>>
    {
        IBookRepository _bookRepository;

        public GetBooksByAuthorQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByAuthor(request.Author);
           
            return Task.FromResult(books);

        }
    }
}
