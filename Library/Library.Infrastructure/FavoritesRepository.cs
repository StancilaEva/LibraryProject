
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private LibraryContext libraryContext;

        public FavoritesRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<Favorite> AddFavoritesAsync(int clientId, int comicId)
        {
            var favorite = new Favorite(clientId, comicId);
            libraryContext.Favorites.Add(new Favorite(clientId, comicId));
            await libraryContext.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> DeleteFavorite(Favorite favorite)
        {
            try
            {
                libraryContext.Favorites.Remove(favorite);
                await libraryContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<Favorite> FindFavorite(int id)
        {
            return await libraryContext.Favorites.SingleOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<ComicBook>> GetAllFavoritesAsync(int clientId)
        {
            var clients = await libraryContext.Clients.Include(x => x.Comics).SingleOrDefaultAsync(x=>x.Id==clientId);
            var comics = clients.Comics;
            return comics.ToList();

        }

        public async Task<List<ComicBook>> GetAllFavoritesAsync(int clientId, int page)
        {
            var client = await libraryContext
                .Clients.Include(x => x.Comics).SingleOrDefaultAsync(x => x.Id == clientId);
            var comics = client.Comics.Skip((page - 1) * 8)
                .Take(8).ToList();
            return comics;
        }

        public async Task<int> GetAllFavoritesPageCountAsync(int clientId, int page)
        {
            var client = await libraryContext
                .Clients.Include(x => x.Comics).SingleOrDefaultAsync(x => x.Id == clientId);
            return client.Comics.Count();
        }

        public async Task<Favorite> GetFavoriteByClientAndComic(int clientId, int comicId)
        {
            return await libraryContext.Favorites.SingleOrDefaultAsync(x=>x.ClientId==clientId&&x.ComicId==comicId);
        }

        public Task<Favorite> RemoveFavoritesAsync(int clientId, int comicId)
        {
            throw new NotImplementedException();
        }

        
    }
}
