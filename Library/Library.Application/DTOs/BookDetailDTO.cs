using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class BookDetailDTO
    {
        public BookDetailDTO(string id,string title, string author, string genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Id { get; set; }
    }
}
