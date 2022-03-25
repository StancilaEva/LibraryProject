using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Lend
    {
        private DateTime startDate;
        private DateTime endDate;

        public Lend()
        {
        }

        public Lend(Book book, Client client, DateTime startDate, DateTime endDate)
        {
            this.Book = book;
            this.Client = client;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public int Id { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
        public DateTime StartDate { get { return startDate; } set { if (DateOnly.FromDateTime(value) >= DateOnly.FromDateTime(DateTime.Today)) startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { if (DateOnly.FromDateTime(value) > DateOnly.FromDateTime(DateTime.Today)) endDate = value; } }


    }
}
