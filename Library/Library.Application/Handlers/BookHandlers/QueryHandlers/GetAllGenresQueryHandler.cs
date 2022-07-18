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
    internal class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, List<string>>
    {
        private IBookRepository _bookRepository;

        public GetAllGenresQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<List<string>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            Genre[] enumGenres = (Genre[])Enum.GetValues(typeof(Genre));
            var stringGenres = new List<string>();
            foreach(var genre in enumGenres)
            {
                stringGenres.Add(GenreConverter.FromEnum(genre));
            }
            stringGenres.Insert(0, "");
            return Task.FromResult(stringGenres);
        }
    }
}
