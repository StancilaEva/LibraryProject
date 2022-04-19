using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.LendQueries
{
    public class GetLendByIdQuery : IRequest<Lend>
    {
        public int Id { get; set; }
    }
}
