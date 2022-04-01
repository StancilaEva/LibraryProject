using Library.Application;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure
{
    public class ComicBookRepository : IBookRepository
    {
        List<ComicBook> bookList;

        public ComicBookRepository()
        {
           bookList = new List<ComicBook>(){
            new ComicBook("1","Dune", "Frank Herbert",Genre.SCIFI),
            new ComicBook("2","Project Hail Mary","Andy Weir",Genre.SCIFI),
            new ComicBook("3","Beach Read","Emily Henry",Genre.ROMANCE),
            new ComicBook("4","Fifth Season","N.K. Jesmin",Genre.FANTASY)
            };
        }
        public List<ComicBook> GetAllBooks()
        {
            return bookList;
        }
        public ComicBook GetBookById(string id)
        {
            return bookList.Where(book => book.Id.Equals(id)).FirstOrDefault();
        }
        public List<ComicBook> FilterBooksByAuthor(string author)
        {
            List<ComicBook> booksByAuthor = bookList.Where(book => book.Author.Equals(author)).ToList();
            return booksByAuthor;
        }
        public List<ComicBook> FilterBooksByGenre(Genre genre)
        {
            List<ComicBook> booksByAuthor = bookList.Where(book => book.Genre.Equals(genre)).ToList();
            return booksByAuthor;
        }

        public void InsertBook(ComicBook book)
        {
            bookList.Add(book);
        }

        public void delete(ComicBook book)
        {
            bookList.Remove(book);
        }

        public void update(ComicBook book)
        {
            int index = bookList.FindIndex(x => x.Id == book.Id);
            bookList.Insert(index, book);
        }
    }
}
