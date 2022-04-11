using Library.Application.DTOs;
using Library.Application.Queries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers
{
    public class GetAllComicBooksQueryHandler : IRequestHandler<GetAllComicBooksQuery, List<ComicBooksDTO>>
    {
        private IBookRepository _bookRepository;

        public GetAllComicBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBooksDTO>> Handle(GetAllComicBooksQuery request, CancellationToken cancellationToken)
        {
            var result =(await _bookRepository.GetAllBooksAsync())
                .Select(book=>new ComicBooksDTO(book.Id,book.Title,book.Publisher,book.Cover)).ToList();

            return result;
        }

    }  
}
