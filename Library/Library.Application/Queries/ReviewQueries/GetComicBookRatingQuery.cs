using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.ReviewQueries
{
    public class GetComicBookRatingQuery : IRequest<double>
    {
        public int ComicId { get; set; }
    }
}
