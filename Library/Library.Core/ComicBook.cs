using Library.Core.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public int IssueNumber { get; set; }
        public ComicBook(int id, string title, string publisher, Genre genre, int issueNumber)
        {
            Id = id;
            Title = title;
            Publisher = publisher;
            Genre = genre;
            IssueNumber = issueNumber;
        }
        public ComicBook(string title, string author, Genre genre, int issueNumber)
        {
            Title = title;
            Publisher = author;
            Genre = genre;
            IssueNumber = issueNumber;
        }
        public override string? ToString()
        {
            return $"{Title} {Publisher}";
        }
    }
}
