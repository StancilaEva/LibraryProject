using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository
    {
        public Task<List<ComicBook>> GetAllBooksAsync();

        public Task<List<ComicBook>> FilterBooksByPublisherAsync(string author);

        public Task<List<ComicBook>> FilterBooksByGenreAsync(Genre genre);
        
        public void InsertBookAsync(ComicBook book);

        public Task<List<ComicBook>> FilterComicBooksAsync(string publisher, string genre, string order, int pageNr);

        public Task<ComicBook> GetBookByIdAsync(int id);

        public Task<ComicBook> UpdateAsync(ComicBook book);

        public Task<ComicBook> DeleteAsync(int id);

        public Task<int> GetFilteredRecordsCount(string publisher, string genre, string order);
        public Task<List<string>> GetAllPublishersAsync();
        public Task<List<string>> GetAllGenresAsync();
        public Task<List<ComicBook>> SearchForComicAsync(string searchString);
    }
}
