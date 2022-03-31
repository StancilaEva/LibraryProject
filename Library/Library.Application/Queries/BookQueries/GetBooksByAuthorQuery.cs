﻿using Library.Application.DTOs;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BookQueries
{
    public class GetBooksByAuthorQuery : IRequest<List<BooksDTO>>
    {
        public String Author { get; set; }
    }
}
