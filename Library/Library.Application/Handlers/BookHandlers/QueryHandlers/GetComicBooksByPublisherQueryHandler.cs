using Library.Application.DTOs;
using Library.Application.Queries.BookQueries;
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
    public class GetComicBooksByPublisherQueryHandler : IRequestHandler<GetComicBooksByPublisherQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByPublisherQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBooksDTO>> Handle(GetComicBooksByPublisherQuery request, CancellationToken cancellationToken)
        {
            var books = (await _bookRepository.FilterBooksByPublisherAsync(request.Publisher))
                .Select(book=>new ComicBooksDTO(book.Id,book.Title,book.Publisher,book.Cover)).ToList();

            return books;

        }
    }
}
