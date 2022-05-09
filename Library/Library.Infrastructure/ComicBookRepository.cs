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

        public async Task<ComicBook> GetBookByIdAsync(int id)
        {
            return await libraryContext.ComicBooks.SingleOrDefaultAsync(book => book.Id==id);
        }

        public async Task<List<ComicBook>> FilterBooksByPublisherAsync(string author)
        {
            List<ComicBook> booksByPublisher = await libraryContext.ComicBooks.Where(book => book.Publisher.Equals(author)).ToListAsync();
            return booksByPublisher;
        }
        
        public async Task<List<ComicBook>> FilterComicBooksAsync(string publisher,string genre,string order,int pageNr)
        {
            var comicsQuery = libraryContext.ComicBooks.AsQueryable();
            
            if (!String.IsNullOrEmpty(publisher))
            {
                comicsQuery = comicsQuery.Where(book => book.Publisher.Equals(publisher));
            }

            if (!String.IsNullOrEmpty(genre))
            {
                comicsQuery = comicsQuery.Where(book => book.Genre == GenreConverter.FromString(genre));
            }

            if (String.IsNullOrEmpty(order) || order.Equals("asc"))
            {
                comicsQuery = comicsQuery.OrderBy(book => book.Title);
            }
            else
            {
                comicsQuery = comicsQuery.OrderByDescending(book => book.Title);
            }

            List<ComicBook> result = await comicsQuery.Skip((pageNr - 1) * 8)//8 benzi desenate pe pagina
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
            await libraryContext.AddRangeAsync();
        }

        public async Task<ComicBook> DeleteAsync(int id)
        {
            var bookToDelete = await libraryContext.ComicBooks.SingleOrDefaultAsync(x=>x.Id==id);
            if (bookToDelete != null)
            {
                libraryContext.ComicBooks.Remove(bookToDelete);
                await libraryContext.SaveChangesAsync();
                return bookToDelete;
            }

            return null;
        }

        public async Task<ComicBook> UpdateAsync(ComicBook book)
        {
            ComicBook comicToUpdate = await libraryContext.ComicBooks.SingleOrDefaultAsync((x)=>x.Id==book.Id);

            if (comicToUpdate != null)
            {
                comicToUpdate.Title = book.Title;
                comicToUpdate.IssueNumber = book.IssueNumber;
                comicToUpdate.Genre = book.Genre;
                comicToUpdate.Publisher = book.Publisher;
                comicToUpdate.Cover = book.Cover;
                await libraryContext.SaveChangesAsync();
                return comicToUpdate;
            }
            return null;
        }

        public async Task<int> GetFilteredRecordsCount(string publisher, string genre, string order)
        {
            var comicsQuery = libraryContext.ComicBooks.AsQueryable();

            if (!String.IsNullOrEmpty(publisher))
            {
                comicsQuery = comicsQuery.Where(book => book.Publisher.Equals(publisher));
            }

            if (!String.IsNullOrEmpty(genre))
            {
                comicsQuery = comicsQuery.Where(book => book.Genre == GenreConverter.FromString(genre));
            }

            if (String.IsNullOrEmpty(order) || order.Equals("asc"))
            {
                comicsQuery = comicsQuery.OrderBy(book => book.Title);
            }
            else
            {
                comicsQuery = comicsQuery.OrderByDescending(book => book.Title);
            }
            var numberOfRecords = await comicsQuery.CountAsync();

            return numberOfRecords;
        }

        public async Task<List<string>> GetAllPublishersAsync()
        {
            List<string> publishers = await libraryContext.ComicBooks.Select(book => book.Publisher).Distinct().ToListAsync();
            return publishers;
        }

        public async Task<List<string>> GetAllGenresAsync()
        {
            List<Genre> genres = await libraryContext.ComicBooks.Select(book => book.Genre).Distinct().ToListAsync();
            return genres.Select(genre => GenreConverter.FromEnum(genre)).ToList();
        }

        public async Task<List<ComicBook>> SearchForComicAsync(string searchString)
        {
            List<ComicBook> comics = await libraryContext.ComicBooks.Where(comic=>comic.Title.ToLower().Contains(searchString.ToLower())).ToListAsync();
            return comics;
            
        }
    }
}
