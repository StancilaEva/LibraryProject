using Library.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ConsoleApp
{
    class MainApp
    {
     //   static ArrayList bookArray;
       // static ArrayList clientArray;
        static void Main(string[] args)
        {
            List<Book> bookArray = new List<Book>(){
            new Book("1","Dune", "Frank Herbert",Genre.SCIFI),
            new Book("2","Project Hail Mary","Andy Weir",Genre.SCIFI),
            new Book("3","Beach Read","Emily Henry",Genre.ROMANCE),
            new Book("4","Fifth Season","N.K. Jesmin",Genre.FANTASY)
            };
            List<Client> clientArray = new List<Client>()
            {
                new Client("1","client1","12345678",new Address("Blvd Iuliu Maniu","Bucuresti","Bucuresti",12)),
                new Client("2","client2","asdfghjkl",new Address("Mihail Moxa","Bucuresti","Bucuresti",11)),
                new Client("3","client3","aefhkeghg",new Address("Bld Vladimirescu","Ploiesti","Prahova",15))
            };
            List<Lend> lends = new List<Lend>()
            {
                new Lend(bookArray[0],clientArray[0],new DateTime(2020,3,15),new DateTime(2020,3,22)),
                new Lend(bookArray[1],clientArray[1],new DateTime(2020,3,15),new DateTime(2020,3,22)),
                new Lend(bookArray[0],clientArray[2],new DateTime(2020,3,5),new DateTime(2020,3,14))
            };
            foreach(Lend lend in lends)
            {
               
            }
           
        }

        public void LendBookToClient(Book book,Client client,DateTime startDate,DateTime endDate,List<Lend> lendList)
        {
            Lend lend = new Lend(book, client, startDate, endDate);
            if (checkIfBookIsAvailabe(lend, lendList))
            {
                lendList.Add(lend);
            }
        }

        public bool checkIfBookIsAvailabe (Lend lend,List<Lend>lendList){
            List<Lend> lendedBooks = lendList.Where(lendedBook => lendedBook.Book.Id == lend.Book.Id).ToList();
            foreach(Lend lendThatContainsBook in lendedBooks)
            {
                if (( DateOnly.FromDateTime(lendThatContainsBook.StartDate) < DateOnly.FromDateTime(lend.StartDate) &&
                  DateOnly.FromDateTime(lendThatContainsBook.EndDate) > DateOnly.FromDateTime(lend.StartDate)) ||
                  (DateOnly.FromDateTime(lendThatContainsBook.StartDate) < DateOnly.FromDateTime(lend.StartDate) &&
                  DateOnly.FromDateTime(lendThatContainsBook.EndDate) > DateOnly.FromDateTime(lend.StartDate)))
                {
                    return false;
                }
                
            }
            return true ;
        }

    }
}
