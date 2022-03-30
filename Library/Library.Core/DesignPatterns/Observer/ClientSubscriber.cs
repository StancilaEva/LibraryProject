using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public abstract class ClientSubscriber
    {
        public void Notify(Book book)
        {
            Console.WriteLine($"I was notified that {book.Title} is now available");
        }
    }
}
