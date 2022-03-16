using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class FilterBookService
    {
        public List<Book> FilterBooksByAuthor(string author, List<Book> books)
        {
            List<Book> booksByAuthor = books.Where(book => book.Author.Equals(author)).ToList();
            return booksByAuthor;
        }
        public List<Book> FilterBooksByGenre(Genre genre, List<Book> books)
        {
            List<Book> booksByGenre = books.Where(book => book.Genre.Equals(genre)).ToList();
            return booksByGenre;
        }
    }
}
