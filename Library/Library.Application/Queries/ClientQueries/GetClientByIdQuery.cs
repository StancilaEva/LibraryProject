using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.ClientQueries
{
    public class GetClientByIdQuery :IRequest<Client>
    {
        public int Id { get; set; }
    }
}
