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
            
            Lend lend = new Lend(clientId, comicId, startDate, endDate);

            libraryContext.Lends.Add(lend);
            await libraryContext.SaveChangesAsync();
            
            
            return lend;
        }

        public async Task<List<Lend>> FilterLendsByBookAsync(int bookId)
        {
            return await libraryContext.Lends.Where(lendedBook => lendedBook.Book.Id.Equals(bookId)).ToListAsync();
        }


        public async Task<Lend> GetLendByIdAsync(int id)
        {
            return await libraryContext.Lends.Include(l=>l.Book)
                .Include(l=>l.Client).SingleOrDefaultAsync(l => l.Id.Equals(id));
            
        }

        public async Task<Lend> ExtendLendAsync(Lend lend,DateTime endDate)
        {
            lend.EndDate = endDate;
            lend.IsExtended = true;
            await libraryContext.SaveChangesAsync();
            return lend;
        }

        public async Task<bool> FindOverlapInLendedComics(int id, DateTime date)
        {
            bool exists = await libraryContext.Lends.Include(l => l.Book)
               .AnyAsync(l => (l.BookId == id) && (l.EndDate >= date && date >= l.StartDate));
            return exists;
        }
    }
}


