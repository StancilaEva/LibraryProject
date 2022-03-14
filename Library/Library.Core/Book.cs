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
        private Genre genre;

        public Book()
        {
        }

        public Book(string title, string author, Genre genre)
        {
            this.title = title;
            this.author = author;
            this.genre = genre;
        }

        public string Title { get { return title; } set { if (value.Length >= 3) title = value; } }
        public string Author { get { return author; } set { if (value.Length >= 3) author = value; } }
        public Genre Genre { get { return genre; } set { genre = value; } }

    }
}
