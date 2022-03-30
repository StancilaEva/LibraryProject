using MainApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Proxy
{
    internal interface ILibraryVIPServices
    {
        public void GetInternetAccess(LibraryMembership libraryMembership);
        public void GetUnlimitedBookAccess(LibraryMembership libraryMembership);
    }
}
