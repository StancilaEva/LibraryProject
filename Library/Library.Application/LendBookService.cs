﻿using Library.Application;
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
            List<Lend> lendList = lendRepository.GetAllLends();
            Lend lend = new Lend(book, client, startDate, endDate);
            if (CheckIfBookIsAvailabe(lend))
            {
                lendList.Add(lend);
            }
            else
            {
                throw new BookNotAvailableException("the book is not available in that time period");
            }
        }

        public bool CheckIfBookIsAvailabe(Lend lend)
        {
            List<Lend> lendedBooks = lendRepository.FilterLendsByBook(lend.Book);
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
