using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class LendBookService
    {
        public void LendBookToClient(Book book, Client client, DateTime startDate, DateTime endDate, List<Lend> lendList)
        {
            Lend lend = new Lend(book, client, startDate, endDate);
            if (CheckIfBookIsAvailabe(lend, lendList))
            {
                lendList.Add(lend);
            }
        }

        public bool CheckIfBookIsAvailabe(Lend lend, List<Lend> lendList)
        {
            List<Lend> lendedBooks = findAllTheLendsThatContainTheBook(lend.Book, lendList);
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

        private static List<Lend> findAllTheLendsThatContainTheBook(Book book, List<Lend> lendList)
        {
            return lendList.Where(lendedBook => lendedBook.Book.Id == book.Id).ToList();
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
