using Library.Application.Queries.LendQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.LendHandlers.QueryHandlers
{
    internal class GetAllLendsThatContainComicQueryHandler : IRequestHandler<GetAllLendsThatContainComicQuery, List<Lend>>
    {
        ILendRepository _lendRepository;

        public GetAllLendsThatContainComicQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<List<Lend>> Handle(GetAllLendsThatContainComicQuery request, CancellationToken cancellationToken)
        {
            return await _lendRepository.AllLendsThatContainComic(request.ComicBookId);
        }
    }
}
