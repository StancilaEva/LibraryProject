using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Decorator
{
    public interface IMembership
    {
        public int GetCost();
        public string GetAccess();
    }
}
