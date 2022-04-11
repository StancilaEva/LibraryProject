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

        public void InsertLendAsync(Lend lend);

        public Task<List<Lend>> FilterLendsByBookAsync(int bookId);

        public Task<ComicBook> GetBookByIdAsync(int id);

        public Task<Client> GetClientByIdAsync(int id);

    }
}
