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

        public Lend(ComicBook book, Client client, DateTime startDate, DateTime endDate)
        {
            this.Book = book;
            this.Client = client;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Lend(DateTime startDate, DateTime endDate, string bookId, string clientId)
        {
            StartDate = startDate;
            EndDate = endDate;
            BookId = bookId;
            ClientId = clientId;
        }

        public int Id { get; set; }
        public ComicBook Book { get; set; }
        public Client Client { get; set; }
        public string BookId { get; set; }
        public string ClientId { get; set; }

        public DateTime StartDate { get { return startDate; } set { if (DateOnly.FromDateTime(value) >= DateOnly.FromDateTime(DateTime.Today)) startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { if (DateOnly.FromDateTime(value) > DateOnly.FromDateTime(DateTime.Today)) endDate = value; } }


    }
}
