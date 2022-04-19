
using Library.Application.Queries.BookQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers
{
    public class GetComicBooksByPublisherQueryHandler : IRequestHandler<GetComicBooksByPublisherQuery, List<ComicBook>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksByPublisherQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBook>> Handle(GetComicBooksByPublisherQuery request, CancellationToken cancellationToken)
        {
            var books = (await _bookRepository.FilterBooksByPublisherAsync(request.Publisher));

            return books;

        }
    }
}
