using Library.Application.DTOs;
using Library.Application.Queries.BookQueries;
using Library.Application.utils;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers.QueryHandlers
{
    public class GetComicBooksPageHandler : IRequestHandler<GetComicBooksPageQuery, List<ComicBooksDTO>>
    {
        IBookRepository _bookRepository;

        public GetComicBooksPageHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBooksDTO>> Handle(GetComicBooksPageQuery request, CancellationToken cancellationToken)
        {

            //TODO muta in repository
            var result = (await _bookRepository.FilterComicBooksAsync(request.Publisher, request.Genre, request.Order, request.Index))
                 .Select(book => new ComicBooksDTO(book.Id, book.Title, book.Publisher, book.Cover)).ToList();
            return result;
            
        }
    }
}
