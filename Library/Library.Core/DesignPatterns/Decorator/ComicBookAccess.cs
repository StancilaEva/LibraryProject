using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Decorator
{
    public class ComicBookAccess : DefaultMembershipDecorator
    {
        public ComicBookAccess(IMembership membership) : base(membership)
        {
        }

        public override string GetAccess()
        {
            return membership.GetAccess() + " got access for comic books";
        }

        public override int GetCost()
        {
            return membership.GetCost() + 25;
        }
    }
}
