using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.RepositoryInterfaces
{
    public interface ILendRepository
    {
        public Task<List<Lend>> GetAllLendsAsync();
        public Task<Lend> InsertLendAsync(int clientId, int comicId, DateTime startDate, DateTime endDate);
        public Task<Lend> GetLendByIdAsync(int id);
        public Task<Lend> ExtendLendAsync(Lend lend, DateTime endDate);
        public Task<bool> FindIfComicHasBeenLentInThatTimePeriodAsync(int id, DateTime startDate, DateTime endDate);
        public Task<bool> FindOverlapInLendedComicsAsync(Lend lend,DateTime newDate);
        public Task<List<Lend>> AllLendsThatContainComicAsync(int comicId);

        public Task<Dictionary<ComicBook, int>> MostBorrowedComicsInThePastMonthAsync();
        public Task<Dictionary<Genre, int>> MostReadGenresAsync();

    }
}
