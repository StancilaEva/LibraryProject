using Library.Application.DTOs;
using Library.Application.Queries;
using Library.Core;
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

        public GetAllComicBooksQueryHandler()
        {
            _bookRepository = new ComicBookRepository();
        }

        public Task<List<ComicBooksDTO>> Handle(GetAllComicBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.GetAllBooks().Select(book=>new ComicBooksDTO(book.Id,book.Title,book.Publisher)).ToList();
            return Task.FromResult(result);
        }

    }  
}
