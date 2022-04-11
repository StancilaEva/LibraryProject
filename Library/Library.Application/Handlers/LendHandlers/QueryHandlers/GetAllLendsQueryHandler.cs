using Library.Application.Queries.LendQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.LendHandlers
{
    public class GetAllLendsQueryHandler : IRequestHandler<GetAllLendsQuery, List<Lend>>
    {
        ILendRepository _lendRepository;

        public GetAllLendsQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<List<Lend>> Handle(GetAllLendsQuery request, CancellationToken cancellationToken)
        {
            var result = await _lendRepository.GetAllLendsAsync();
            return result;
        }
    }
}
