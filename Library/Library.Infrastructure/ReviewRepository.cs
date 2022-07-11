

using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {
        LibraryContext libraryContext;

        public ReviewRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }

        public async Task<Review> WriteReviewAsync(Review review)
        {
            libraryContext.Reviews.Add(review);
            await libraryContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReviewById(int id)
        {
            return null;
        }

        public async Task<double> GetComicBookRatingAsync(int comicId)
        {
            try
            {
                return await libraryContext.Reviews.Where(x => x.ComicId.Equals(comicId)).AverageAsync(x => x.Rating);
            }
            catch(InvalidOperationException ex)
            {
                return 0;
            }
        }

        public async Task<List<Review>> GetAllComicReviewsAsync(int comicId)
        {
            return await libraryContext.Reviews.Where(x => x.ComicId.Equals(comicId)).Include(x=>x.Author).ToListAsync();
        }

        public async Task<Dictionary<int,double>> BestRatedComicsAsync()
        {
            var getBestRatedComics = await libraryContext.Reviews
                .GroupBy((review) => review.ComicId)
                .Select(gr =>
                new
                {
                    Comic = gr.Key,
                    Mean = gr.Average(x=>x.Rating)
                })
                .OrderByDescending(x => x.Mean)
                .Take(3)
                .ToDictionaryAsync(x => x.Comic, x => x.Mean);
            return getBestRatedComics;
        }
    }
}
