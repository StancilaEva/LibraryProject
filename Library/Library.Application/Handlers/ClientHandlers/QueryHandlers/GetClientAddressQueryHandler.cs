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
    public class GetClientAddressQueryHandler : IRequestHandler<GetClientAddressQuery,Address>
    {
        IClientRepository _clientRepository;

        public GetClientAddressQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Address> Handle(GetClientAddressQuery request, CancellationToken cancellationToken)
        {
            Address address = await _clientRepository.GetClientAddress(request.Id);
            return address;
        }
    }
}
