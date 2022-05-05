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
    internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<string>>
    {
        private IBookRepository _bookRepository;

        public GetAllGenresQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<string>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _bookRepository.GetAllGenresAsync();
            genres.Insert(0, "");
            return genres;
        }
    }
}
