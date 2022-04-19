using Library.Application;
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
    public class LendRepository : ILendRepository
    {
        LibraryContext libraryContext;

        public LendRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public LendRepository()
        {
        }

        public async Task<List<Lend>> GetAllLendsAsync()
        {
            return await libraryContext.Lends.ToListAsync();
        }

        public async Task<Lend> InsertLendAsync(int clientId, int comicId, DateTime startDate, DateTime endDate)
        {
            Client client = libraryContext.Clients.FirstOrDefault(client => client.Id == clientId);   
            ComicBook comicBook = libraryContext.ComicBooks.FirstOrDefault(comic => comic.Id == comicId);
            
            Lend lend = new Lend(comicBook, client, startDate, endDate);

            libraryContext.Lends.Add(lend);
            await libraryContext.SaveChangesAsync();

            
            return lend;
        }

        public async Task<List<Lend>> FilterLendsByBookAsync(int bookId)
        {
            return await libraryContext.Lends.Where(lendedBook => lendedBook.Book.Id.Equals(bookId)).ToListAsync();
        }

        public async Task<ComicBook> GetBookByIdAsync(int id)
        {
            ComicBook comicBook = await libraryContext.ComicBooks.FirstOrDefaultAsync(book=>book.Id.Equals(id));
            if(comicBook == null)
            {
                throw new InvalidOperationException("comic book not found");
            }

            return comicBook;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            Client client = await libraryContext.Clients.Include(client=>client.Address)
                .FirstOrDefaultAsync(client => client.Id.Equals(id));
            if (client == null)
            {
                throw new InvalidOperationException("client not found");
            }

            return client;
        }

        public async Task<Lend> GetLendByIdAsync(int id)
        {
            Lend lend = await libraryContext.Lends.Include(l=>l.Book).Include(l=>l.Client).FirstOrDefaultAsync(l => l.Id.Equals(id));
            return lend;
        }
    }
}


