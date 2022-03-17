using Library.Application;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        List<Book> bookList;

        public BookRepository()
        {
           bookList = new List<Book>(){
            new Book("1","Dune", "Frank Herbert",Genre.SCIFI),
            new Book("2","Project Hail Mary","Andy Weir",Genre.SCIFI),
            new Book("3","Beach Read","Emily Henry",Genre.ROMANCE),
            new Book("4","Fifth Season","N.K. Jesmin",Genre.FANTASY)
            };
        }
        public List<Book> GetAllBooks()
        {
            return bookList;
        }

        public List<Book> FilterBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = bookList.Where(book => book.Author.Equals(author)).ToList();
            return booksByAuthor;
        }
        public List<Book> FilterBooksByGenre(Genre genre)
        {
            List<Book> booksByAuthor = bookList.Where(book => book.Genre.Equals(genre)).ToList();
            return booksByAuthor;
        }



        public void InsertBook(Book book)
        {
            bookList.Add(book);
        }
    }
}
