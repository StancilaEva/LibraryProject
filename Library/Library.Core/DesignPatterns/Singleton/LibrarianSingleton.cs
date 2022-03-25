using Library.Core.FactoryDesignPattern.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Singleton
{
    public class LibrarianSingleton //presupunem ca exista un singur bibliotecar per biblioteca
    {
        private static LibrarianSingleton librarianSingleton;
        private static readonly object padlock = new object();

        public IMembershipFactory MembershipFactory { get; set; } // bibliotecarul acorda abonamente

        private LibrarianSingleton()
        {
        }

        public static LibrarianSingleton GetInstance()
        {

            lock (padlock)
            {
                if (librarianSingleton == null)
                {
                    librarianSingleton = new LibrarianSingleton();
                }
            }
            return librarianSingleton;
        }

    }
}
