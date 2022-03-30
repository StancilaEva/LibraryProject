using MainApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Proxy
{
    public class LibraryVIPServices : ILibraryVIPServices
    {
        public void GetInternetAccess(LibraryMembership libraryMembership)
        {
            Console.WriteLine("...Connecting to the library wi-fi");
        }

        public void GetUnlimitedBookAccess(LibraryMembership libraryMembership)
        {
            Console.WriteLine("Got more books to explore");
        }
    }
}
