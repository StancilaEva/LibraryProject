using Library.Application;
using Library.Application.Exceptions;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class LendBookService
    {
        ILendRepository lendRepository;

        public LendBookService(ILendRepository lendRepository)
        {
            this.lendRepository = lendRepository;
        }

        public void LendBookToClient(Book book, Client client, DateTime startDate, DateTime endDate)
        {
            List<Lend> lendList = lendRepository.getAllLends();
            Lend lend = new Lend(book, client, startDate, endDate);
            if (CheckIfBookIsAvailabe(lend,lendList))
            {
                lendList.Add(lend);
            }
            else
            {
                throw new BookNotAvailableException("the book is not available in that time period");
            }
        }

        public bool CheckIfBookIsAvailabe(Lend lend, List<Lend> lendList)
        {
            List<Lend> lendedBooks = FindAllTheLendsThatContainTheBook(lend.Book);
            foreach (Lend lendThatContainsBook in lendedBooks)
            {
                if (BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, lend.StartDate) ||
                    BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, lend.EndDate))
                {
                    return false;
                }

            }
            return true;
        }

        public List<Lend> FindAllTheLendsThatContainTheBook(Book book)
        {
            List<Lend> lendList = lendRepository.getAllLends();
            return lendList.Where(lendedBook => lendedBook.Book.Id.Equals(book.Id)).ToList();
        }

        public bool BetweenTwoDates(DateTime start, DateTime end,DateTime date)
        {
            if (DateOnly.FromDateTime(start) < DateOnly.FromDateTime(date) &&
                DateOnly.FromDateTime(end) > DateOnly.FromDateTime(date))
                return true;
            else
                return false;
        }
    }
}
