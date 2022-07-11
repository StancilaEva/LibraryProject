using Library.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public Client Author { get; set; }
        public int ClientId { get; set; }
        public ComicBook Comic { get; set; }
        public int ComicId { get; set; }


        public Review(string reviewText, int rating, Client author, ComicBook comic)
        {
            if (rating >= 0 && rating <= 5)
                Rating = rating;
            else
                throw new InvalidReviewException("the rating should be between 0 and 5");
            ReviewText = reviewText;
            Author = author;
            Comic = comic;
        }

        public Review(string reviewText, int rating, int clientId, int comicId)
        {
            if (rating >= 0 && rating <= 5)
                Rating = rating;
            else
                throw new InvalidReviewException("the rating should be between 0 and 5");
            ReviewText = reviewText;
            ClientId = clientId;
            ComicId = comicId;
        }

        public Review(int id, string reviewText, int rating, int clientId, int comicId)
        {
            Id = id;
            ReviewText = reviewText;
            Rating = rating;
            ClientId = clientId;
            ComicId = comicId;
        }

        public Review(int id, string reviewText, int rating, Client author, ComicBook comic)
        {
            Id = id;
            ReviewText = reviewText;
            Rating = rating;
            Author = author;
            Comic = comic;
        }
    }
}
