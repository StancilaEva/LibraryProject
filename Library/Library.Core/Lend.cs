using Library.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Lend
    {
        public int Id { get; set; }
        public ComicBook Book { get; set; }
        public int BookId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsExtended { get; set; }

        public Lend()
        {
        }

        public Lend(ComicBook book, Client client, DateTime startDate, DateTime endDate)
        {
            if (DateOnly.FromDateTime(startDate) >= DateOnly.FromDateTime(DateTime.Today))
            {
                StartDate = startDate;
            }
            else 
            {
                throw new InvalidDateException("Invalid date");
            }

            if (DateOnly.FromDateTime(endDate) > DateOnly.FromDateTime(DateTime.Today))
            {
                EndDate = endDate;
            }
            else
            {
                throw new InvalidDateException("Invalid date");
            }
            if (DateOnly.FromDateTime(startDate) > DateOnly.FromDateTime(endDate))
            {
                throw new InvalidDateException("Invalid date");
            }
            this.Book = book;
            this.Client = client;
            IsExtended = false;
        }

        public Lend(int clientId, int comicId, DateTime startDate, DateTime endDate)
        {
            if (DateOnly.FromDateTime(startDate) >= DateOnly.FromDateTime(DateTime.Today))
            {
                StartDate = startDate;
            } else {
                throw new InvalidDateException("Invalid date");
            }

            if (DateOnly.FromDateTime(endDate) > DateOnly.FromDateTime(DateTime.Today))
            {
                EndDate = endDate;
            } else {
                throw new InvalidDateException("Invalid date");
            }

            if (DateOnly.FromDateTime(startDate) > DateOnly.FromDateTime(endDate))
            {
                throw new InvalidDateException("Invalid date");
            }

            this.ClientId = clientId;
            this.BookId = comicId;
            IsExtended = false;
        }
    }
}
