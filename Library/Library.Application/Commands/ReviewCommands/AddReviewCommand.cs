using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.ReviewCommands
{
    public class AddReviewCommand : IRequest<Review>
    {
        public string TextReview { get; set; }
        public int Rating { get; set; }
        public int ComicId { get; set; }
        public int ClientId { get; set; }
    }
}
