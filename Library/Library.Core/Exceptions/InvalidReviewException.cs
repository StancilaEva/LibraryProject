using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class InvalidReviewException : Exception
    {
        public InvalidReviewException(string message) : base(message)
        {
        }
    }
}
