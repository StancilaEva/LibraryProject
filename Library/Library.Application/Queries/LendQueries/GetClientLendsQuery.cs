using Library.Application.Paging;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.ClientQueries
{
    public class GetClientLendsQuery : IRequest<LendPage>
    {
        public int IdClient { get; set; }
        public int Page { get; set; }
        public TimePeriod? Time { get; set; }
    }
}
