using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries
{
    public class GetAllComicBooksQuery : IRequest<List<ComicBook>>
    {

    }
}
