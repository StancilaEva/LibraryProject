using Library.Application.Queries.BookQueries;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers.QueryHandlers
{
    public class GetAllPublishersQueryHandler : IRequestHandler<GetAllPublishersQuery, List<string>>
    {
        private IBookRepository _bookRepository;

        public GetAllPublishersQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<string>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var publishers =  await _bookRepository.GetAllPublishersAsync();
            publishers.Insert(0, "");
            return publishers;
        }
    }
}
