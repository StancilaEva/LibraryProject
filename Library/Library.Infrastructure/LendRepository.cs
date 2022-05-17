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

        public async Task<bool> FindIfComicHasBeenLentInThatTimePeriodAsync(int id, DateTime startDate,DateTime endDate) 
        {
            bool exists = await libraryContext.Lends.Include(l=>l.Book)
                .AnyAsync(l=> (l.BookId == id) && (
                (l.EndDate >= startDate && startDate >= l.StartDate) || //cazul in care prima zi de imprumut se afla intre prima zi si ultima zi a altui imprumut
                (l.EndDate >= endDate && endDate >= l.StartDate) ||
                (l.StartDate <= startDate && l.EndDate >= endDate)|| //cazul in care un imprumut acopera in intregime imprumutul nostru
                (startDate<=l.StartDate && endDate>=l.EndDate)));
            return exists;
        }

        public async Task<bool> FindOverlapInLendedComicsAsync(Lend lend, DateTime date)
        {
            bool exists = await libraryContext.Lends.Include(l => l.Book)
               .AnyAsync(l => (l.BookId == lend.Book.Id && l.Id!=lend.Id) && (
               (l.EndDate >= date && date >= l.StartDate) ||  
               (l.StartDate>=lend.StartDate && date >= l.EndDate)));
            return exists;
        }

        public async Task<List<Lend>> AllLendsThatContainComic(int comicId)
        {
            return await libraryContext.Lends.Include(l=>l.Client)
                .Where(l => l.BookId == comicId).ToListAsync();
        } 
    }
}


