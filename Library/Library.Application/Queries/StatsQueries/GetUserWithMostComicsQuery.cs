using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.StatsQueries
{
    public class GetUserWithMostComicsQuery : IRequest<(Client,int)>
    {
    }
}
