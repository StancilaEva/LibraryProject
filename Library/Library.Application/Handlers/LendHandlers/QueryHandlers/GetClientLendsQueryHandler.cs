using Library.Application.Paging;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.ClientHandlers.QueryHandlers
{
    public class GetClientLendsQueryHandler : IRequestHandler<GetClientLendsQuery, LendPage>
    {
        private ILendRepository _lendRepository;

        public GetClientLendsQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<LendPage> Handle(GetClientLendsQuery request, CancellationToken cancellationToken)
        {
            var result = await _lendRepository.GetAllLendsFromClientAsync(request.IdClient,request.Page,request.Time);
            var count = await _lendRepository.GetAllLendsCountFromClientAsync(request.IdClient, request.Page,request.Time);
            return new LendPage()
            {
                Lends = result,
                Count = count
            };
        }
    }
}
