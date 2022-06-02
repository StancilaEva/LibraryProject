
using Library.Application.Paging;
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
    public class GetComicBooksPageHandler : IRequestHandler<GetComicBooksPageQuery, ComicBookPage>
    {
        IBookRepository _bookRepository;

        public GetComicBooksPageHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ComicBookPage> Handle(GetComicBooksPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.FilterComicBooksAsync(request.Publisher, request.Genre, request.Order, request.Index);
            var pageNumber = await _bookRepository.GetFilteredRecordsCount(request.Publisher, request.Genre, request.Order);

            return new ComicBookPage() { 
                Comics=result,
                Count=pageNumber
            };
            
        }
    }
}
