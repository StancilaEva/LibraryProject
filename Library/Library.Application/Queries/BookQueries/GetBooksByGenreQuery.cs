﻿using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries
{
    public class GetBooksByGenreQuery : IRequest<List<Book>>
    {
        public Genre Genre { get; set; }
    }
}
