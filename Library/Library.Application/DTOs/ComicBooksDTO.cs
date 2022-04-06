using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class ComicBooksDTO
    {
        public ComicBooksDTO(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }  
    }
}
