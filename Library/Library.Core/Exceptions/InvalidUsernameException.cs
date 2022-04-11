using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    internal class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message)
        {
        }
    }
}
