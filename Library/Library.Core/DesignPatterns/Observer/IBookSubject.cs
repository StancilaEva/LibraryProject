using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public interface IBookSubject
    {
        public void AddSubcription(IUserObserver userObserver);

        public abstract void IsNowAvailable();
    }
}
