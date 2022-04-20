using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Exceptions
{
    public class ExtendDateNotValidException : Exception
    {
        public ExtendDateNotValidException(string message) : base(message)
        {
        }
    }
}
