using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Decorator
{
    public class DefaultMembership : IMembership
    {
      

        public int GetCost()
        {
            return 50;
        }

        public string GetAccess()
        {
            return " got library access ";
        }
    }
}
