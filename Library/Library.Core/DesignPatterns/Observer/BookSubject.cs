using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public class BookSubject : IBookSubject
    {
        Book book;
        List<IUserObserver> users;
        public BookSubject(Book book)
        {
            this.book = book;
            users = new List<IUserObserver>();
        }

        public void AddSubcription(IUserObserver userObserver)
        {
            users.Add(userObserver);
        }

        public void Unsubscribe(IUserObserver userObserver)
        {
            users.Remove(userObserver);
        }

        public void IsNowAvailable()
        {
            users.ForEach(user => user.Notify(book));
        }
    }
}
