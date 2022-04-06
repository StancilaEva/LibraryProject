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
    public class GetComicBooksByPublisherQueryHandler : IRequestHandler<GetComicBooksByPublisherQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByPublisherQueryHandler()
        {
            _bookRepository = new ComicBookRepository();
        }

        public Task<List<ComicBooksDTO>> Handle(GetComicBooksByPublisherQuery request, CancellationToken cancellationToken)
        {
            var books = _bookRepository.FilterBooksByPublisher(request.Publisher)
                .Select(book=>new ComicBooksDTO(book.Id,book.Title,book.Publisher)).ToList();
           
            return Task.FromResult(books);

        }
    }
}
