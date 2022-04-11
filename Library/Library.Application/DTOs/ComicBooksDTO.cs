using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class ComicBooksDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public String Cover { get; set; }

        public ComicBooksDTO(int id, string title, string author,String cover)
        {
            Id = id;
            Title = title;
            Author = author;
            Cover = cover;
        }

    }
}
