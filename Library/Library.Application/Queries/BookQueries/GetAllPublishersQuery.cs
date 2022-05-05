using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries
{
    public class GetAllPublishersQuery : IRequest<List<string>>
    {
    }
}
