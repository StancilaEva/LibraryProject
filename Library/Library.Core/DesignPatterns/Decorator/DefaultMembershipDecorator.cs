using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Decorator
{
    public abstract class DefaultMembershipDecorator : IMembership
    {
        protected IMembership membership;

        protected DefaultMembershipDecorator(IMembership membership)
        {
            this.membership = membership;
        }

        public abstract string GetAccess();

        public abstract int GetCost();
    }
}
