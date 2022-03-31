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

namespace Library.Application.Handlers.BookHandlers
{
    public class GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, List<BooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetBooksByAuthorQueryHandler()
        {
            _bookRepository = new BookRepository();
        }

        public Task<List<BooksDTO>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByAuthor(request.Author)
                .Select(book=>new BooksDTO(book.Id,book.Title,book.Author)).ToList();
           
            return Task.FromResult(books);

        }
    }
}
