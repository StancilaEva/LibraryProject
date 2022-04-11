using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class ComicBookDetailDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }
        public int IssueNumber { get; set; }
        public String Cover { get; set; }

        public ComicBookDetailDTO(int id, string title, string author, string genre, int issueNumber, String cover)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            IssueNumber = issueNumber;
            Cover = cover;
        }

    }
}
