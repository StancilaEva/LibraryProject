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
    public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorQuery, List<Book>>
    {
        IBookRepository _bookRepository;

        public GetBooksByAuthorHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<Book>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.GetAllBooks().Where(book => book.Author.Equals(request.Author)).ToList();
            // nu ar fi mai bine sa chem direct getBooksByAuthor din repository
            return Task.FromResult(books);

        }
    }
}
