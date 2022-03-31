using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class BooksDTO
    {
        public BooksDTO(string id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }  
    }
}
