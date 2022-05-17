
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class FileCommand : IRequest<string>
    {
        public IFormFile File { get; set; }
    }
}
