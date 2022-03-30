using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DesignPatterns.Observer
{
    public abstract class BookObserver
    {
        protected List<ClientSubscriber> clientSubscribers = new List<ClientSubscriber>();


        protected BookObserver(List<ClientSubscriber> clientSubscribers)
        {
            this.clientSubscribers = clientSubscribers;
        }


        public void AddSubcription(ClientSubscriber clientSubscriber)
        {
            clientSubscribers.Add(clientSubscriber);
        }

        public abstract void IsNowAvailable();
        

    }
}
