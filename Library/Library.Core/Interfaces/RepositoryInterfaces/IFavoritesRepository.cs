using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.RepositoryInterfaces
{
    public interface IFavoritesRepository
    {
        public Task<Favorite> AddFavoritesAsync(int clientId, int comicId);
        public Task<Favorite> RemoveFavoritesAsync(int clientId, int comicId);
        public Task<List<ComicBook>> GetAllFavoritesAsync(int clientId);
        public Task<bool> DeleteFavorite(Favorite favorite);
        public Task<Favorite> GetFavoriteByClientAndComic(int clientId, int comicId);
        public Task<List<ComicBook>> GetAllFavoritesAsync(int clientId, int page);
        public Task<int> GetAllFavoritesPageCountAsync(int clientId, int page);

    }
}
