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

        public async void InsertLendAsync(Lend lend)
        {
            libraryContext.Lends.Add(lend);
        }

        public async Task<List<Lend>> FilterLendsByBookAsync(int bookId)
        {
            return await  libraryContext.Lends.Where(lendedBook => lendedBook.Book.Id.Equals(bookId)).ToListAsync();
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
            Client client = await libraryContext.Clients.FirstOrDefaultAsync(client => client.Id.Equals(id));
            if (client == null)
            {
                throw new InvalidOperationException("client not found");
            }

            return client;
        }
    }
}


