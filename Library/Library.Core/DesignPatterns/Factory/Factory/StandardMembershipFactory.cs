using Library.Core.FactoryDesignPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class StandardMembershipFactory : IMembershipFactory
    {
        public LibraryMembership Create()
        {
            return new LibraryStandardMembership();
        }
    }
}
