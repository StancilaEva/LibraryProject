using Library.Application.DTOs;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries
{
    public class GetComicBooksByGenreQuery : IRequest<List<ComicBooksDTO>>
    {
        public Genre Genre { get; set; }
    }
}
