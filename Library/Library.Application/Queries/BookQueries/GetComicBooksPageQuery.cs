using Library.Application.Paging;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries
{
    public class GetComicBooksPageQuery : IRequest<ComicBookPage>
    {
        public int Index { get; set; }

        public string? Order { get; set; }

        public string? Publisher { get; set; }

        public string? Genre { get; set; }

    }
}
