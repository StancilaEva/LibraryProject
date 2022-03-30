using MainApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Proxy
{
    public class LibraryVIPServicesProxy : ILibraryVIPServices
    {
        private LibraryVIPServices libraryVIPServices;

        public LibraryVIPServicesProxy(LibraryVIPServices libraryVIPServices)
        {
            this.libraryVIPServices = libraryVIPServices;
        }

        public void GetInternetAccess(LibraryMembership libraryMembership)
        {
            if (isValid(libraryMembership))
            {
                libraryVIPServices.GetInternetAccess(libraryMembership);
            }
        }


        public void GetUnlimitedBookAccess(LibraryMembership libraryMembership)
        {
            if (isValid(libraryMembership))
            {
                libraryVIPServices.GetUnlimitedBookAccess(libraryMembership);
            }
        }


        private bool isValid(LibraryMembership libraryMembership)
        {
            if (libraryMembership is LibraryPremiumMembership)
                return true;
            else
            {
                Console.WriteLine("Only Premium members can access this feature");
                return false;
            }
        }
    }
}
