using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Exceptions
{
    public class NotEnoughComicsException : Exception
    {
        public NotEnoughComicsException(string? message) : base(message)
        {
        }
    }
}
