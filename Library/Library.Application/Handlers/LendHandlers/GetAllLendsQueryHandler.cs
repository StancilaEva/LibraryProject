using Library.Application.Queries.LendQueries;
using Library.Core;
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

        public Task<List<Lend>> Handle(GetAllLendsQuery request, CancellationToken cancellationToken)
        {
            var result = _lendRepository.getAllLends();
            return Task.FromResult(result);
        }
    }
}
