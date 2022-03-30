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
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private IBookRepository _bookRepository;

        public GetAllBooksQueryHandler()
        {
            _bookRepository = new BookRepository();
        }

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = _bookRepository.GetAllBooks();
            return Task.FromResult(result);
        }

    }  
}
