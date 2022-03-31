using Library.Core.DesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Book 
    {
        private string title;
        private string author;

        public Book() 
        {
        }

        public Book(string id, string title, string author, Genre genre) 
        {
            this.Id = id;
            this.title = title;
            this.author = author;
            this.Genre = genre;

        }
        public Book(string title, string author, Genre genre)
        {
            this.title = title;
            this.author = author;
            this.Genre = genre;
        }

        public string Title { get { return title; } set { if (value.Length >= 3) title = value; } }
        public string Author { get { return author; } set { if (value.Length >= 3) author = value; } }
        public Genre Genre { get; set; }
        public string Id { get; set; }


        public override string? ToString()
        {
            return $"{title} {author}";
        }
    }
}
