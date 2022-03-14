using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Lend
    {
        private Book book;
        private Client client;
        private DateTime startDate;
        private DateTime endDate;

        public Lend()
        {
        }

        public Lend(Book book, Client client, DateTime startDate, DateTime endDate)
        {
            this.book = book;
            this.client = client;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Book Book { get { return book; } set { book = value; } }
        public Client Client { get { return client; } set { client = value; } }
        public DateTime StartDate { get { return startDate; } set { if (DateOnly.FromDateTime(value) >= DateOnly.FromDateTime(DateTime.Today)) startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { if (DateOnly.FromDateTime(value) > DateOnly.FromDateTime(DateTime.Today)) endDate = value; } }


    }
}
