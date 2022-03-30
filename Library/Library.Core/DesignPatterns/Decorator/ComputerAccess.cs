using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Decorator
{
    public class ComputerAccess : DefaultMembershipDecorator
    {
        public ComputerAccess(IMembership membership) : base(membership)
        {
        }

        public override string GetAccess()
        {
            return membership.GetAccess() + ", got computer access";
        }

        public override int GetCost()
        {
            return membership.GetCost() + 25;
        }
    }
}
