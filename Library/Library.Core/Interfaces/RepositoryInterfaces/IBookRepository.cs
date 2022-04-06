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
        public List<ComicBook> GetAllBooks();
        public List<ComicBook> FilterBooksByPublisher(string author);
        public List<ComicBook> FilterBooksByGenre(Genre genre);
        public void InsertBook(ComicBook book);


    }
}
