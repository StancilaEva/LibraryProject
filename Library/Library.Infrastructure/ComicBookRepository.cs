using Library.Application;
using Library.Application.utils;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure
{
    public class ComicBookRepository : IBookRepository
    {
        private LibraryContext libraryContext;

        public ComicBookRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<List<ComicBook>> GetAllBooksAsync()
        {
            return await libraryContext.ComicBooks.ToListAsync();
        }

        public async Task<ComicBook> GetBookByIdAsync(string id)
        {
            return await libraryContext.ComicBooks.FirstOrDefaultAsync(book => book.Id.Equals(id));
        }

        public async Task<List<ComicBook>> FilterBooksByPublisherAsync(string author)
        {
            List<ComicBook> booksByPublisher = await libraryContext.ComicBooks.Where(book => book.Publisher.Equals(author)).ToListAsync();
            return booksByPublisher;
        }
        
        public async Task<List<ComicBook>> FilterComicBooksAsync(string publisher,string genre,string order,int pageNr)
        {
            var comics = libraryContext.ComicBooks;
            if (publisher != null)
            {
                comics.Where(book => book.Publisher.Equals(publisher));
            }

            if (genre != null)
            {
                comics.Where(book => book.Genre == GenreConverter.FromString(genre));
            }

            if (order == null || order.Equals("asc"))
            {
                comics.OrderBy(book => book.Title);
            }
            else
            {
                comics.OrderByDescending(book => book.Title);
            }

            List<ComicBook> result =await comics.Skip((pageNr - 1) * 8)//8 benzi desenate pe pagina
                .Take(8)
                .ToListAsync();
            return result;
        }

        public async Task<List<ComicBook>> FilterBooksByGenreAsync(Genre genre)
        {
            List<ComicBook> booksByGenre = await libraryContext.ComicBooks.Where(book => book.Genre.Equals(genre)).ToListAsync();

            return booksByGenre;
        }

        public async void InsertBookAsync(ComicBook book)
        {
            libraryContext.ComicBooks.Add(book);
        }

        public async void deleteAsync(ComicBook book)
        {
            libraryContext.ComicBooks.Remove(book);
        }

        public async void updateAsync(ComicBook book)
        {
            ComicBook comicToUpdate = libraryContext.ComicBooks.FirstOrDefault((x)=>x.Id==book.Id);

            if (comicToUpdate != null)
            {
                comicToUpdate = book;
            }
        }

    }
}
