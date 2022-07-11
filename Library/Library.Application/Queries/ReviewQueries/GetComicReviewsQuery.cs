using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.ReviewQueries
{
    public class GetComicReviewsQuery : IRequest<List<Review>>
    {
        public int ComicId { get; set; } 
    }
}
