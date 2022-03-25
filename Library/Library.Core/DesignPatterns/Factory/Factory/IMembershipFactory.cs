using MainApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.FactoryDesignPattern.Factory
{
    public interface IMembershipFactory
    {

        public LibraryMembership Create();
    }
}
