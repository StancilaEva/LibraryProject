using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Favorite
    {
        public int Id { get; set; }
        public int ComicId { get; set; }
        public int ClientId { get; set; }
        public ComicBook ComicBook { get; set; }
        public Client Client { get; set; }

        public Favorite(int clientId, int comicId)
        {
            ComicId = comicId;
            ClientId = clientId;
        }

        public Favorite(ComicBook comicBook, Client client)
        {
            ComicBook = comicBook;
            Client = client;
        }
    }
}
