using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class EmailAlreadyInUseException : Exception
    {
        public EmailAlreadyInUseException(string message) : base(message)
        {
        }
    }
}
