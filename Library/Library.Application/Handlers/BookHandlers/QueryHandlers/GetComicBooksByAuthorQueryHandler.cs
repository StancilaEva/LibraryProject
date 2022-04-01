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
    public class GetComicBooksByAuthorQueryHandler : IRequestHandler<GetComicBooksByAuthorQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByAuthorQueryHandler()
        {
            _bookRepository = new ComicBookRepository();
        }

        public Task<List<ComicBooksDTO>> Handle(GetComicBooksByAuthorQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByAuthor(request.Author)
                .Select(book=>new ComicBooksDTO(book.Id,book.Title,book.Author)).ToList();
           
            return Task.FromResult(books);

        }
    }
}
