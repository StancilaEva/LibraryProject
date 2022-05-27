using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class InvalidUserCredentialsException : Exception
    {
        public InvalidUserCredentialsException(string message) : base(message)
        {
        }
    }
}
