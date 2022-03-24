using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public List<Book> FilterBooksByAuthor(string author);
        public List<Book> FilterBooksByGenre(Genre genre);
        public void InsertBook(Book book);


    }
}
