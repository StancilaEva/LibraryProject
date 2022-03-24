using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class PremiumMembershipFactory : IMembershipFactory
    {
        public LibraryMembership Create()
        {
            return new LibraryPremiumMembership();
        }
    }
}
