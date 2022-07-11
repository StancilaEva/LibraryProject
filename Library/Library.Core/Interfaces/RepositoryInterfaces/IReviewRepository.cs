using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces.RepositoryInterfaces
{
    public interface IReviewRepository
    {
        public Task<Review> WriteReviewAsync(Review review);
        public Task<double> GetComicBookRatingAsync(int comicId);
        public Task<List<Review>> GetAllComicReviewsAsync(int comicId);
        public Task<Dictionary<int, double>> BestRatedComicsAsync();
    }
}
