
using Library.Application.Queries.BookQueries;
using Library.Application.utils;
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
    public class GetComicBookByIdQueryHandler : IRequestHandler<GetComicBookByIdQuery, ComicBook>
    {
        private IBookRepository _bookRepository;

        public GetComicBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ComicBook> Handle(GetComicBookByIdQuery request, CancellationToken cancellationToken)
        {
            var comicBookById = await _bookRepository.GetBookByIdAsync(request.Id);
            
            return comicBookById;
        }
    }
}
