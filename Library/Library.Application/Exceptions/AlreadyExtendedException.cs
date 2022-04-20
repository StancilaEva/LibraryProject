using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Exceptions
{
    public class AlreadyExtendedException : Exception
    {
        public AlreadyExtendedException(string? message) : base(message)
        {
        }
    }
}
