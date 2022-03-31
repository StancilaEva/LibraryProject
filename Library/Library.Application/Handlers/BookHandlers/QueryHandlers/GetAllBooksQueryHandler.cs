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
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BooksDTO>>
    {
        private IBookRepository _bookRepository;

        public GetAllBooksQueryHandler()
        {
            _bookRepository = new BookRepository();
        }

        public Task<List<BooksDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.GetAllBooks().Select(book=>new BooksDTO(book.Id,book.Title,book.Author)).ToList();
            return Task.FromResult(result);
        }

    }  
}
