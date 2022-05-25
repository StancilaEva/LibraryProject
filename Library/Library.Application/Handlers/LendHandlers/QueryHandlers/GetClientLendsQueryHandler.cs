﻿using Library.Application.Queries.ClientQueries;
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
    public class GetClientLendsQueryHandler : IRequestHandler<GetClientLendsQuery, List<Lend>>
    {
        IClientRepository _clientRepository;

        public GetClientLendsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Lend>> Handle(GetClientLendsQuery request, CancellationToken cancellationToken)
        {
            var result = await _clientRepository.GetAllClientLends(request.IdClient);

            return result;
        }
    }
}