using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.StatsQueries
{
    public class GetMostReadPublishersQuery : IRequest<Dictionary<string,int>>
    {
    }
}
