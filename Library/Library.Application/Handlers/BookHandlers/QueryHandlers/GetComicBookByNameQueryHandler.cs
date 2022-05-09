using Library.Application.Queries.BookQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers.QueryHandlers
{
    public class GetComicBookByNameQueryHandler : IRequestHandler<GetComicBookByNameQuery, List<ComicBook>>
    {
        IBookRepository _bookRepository;

        public GetComicBookByNameQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<ComicBook>> Handle(GetComicBookByNameQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.SearchForComicAsync(request.SearchString);
        }
    }
}
