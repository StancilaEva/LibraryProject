using Library.Application.Queries.ClientQueries;
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
    internal class GetLendByIdQueryHandler : IRequestHandler<GetLendByIdQuery, Lend>
    {
        ILendRepository _lendRepository;

        public GetLendByIdQueryHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<Lend> Handle(GetLendByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _lendRepository.GetLendByIdAsync(request.Id);
            if (result.Client.Id != request.UserId)
                throw new UnauthorizedAccessException();
            return result;
        }
    }
}
