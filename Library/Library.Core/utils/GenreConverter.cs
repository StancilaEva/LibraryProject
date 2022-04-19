using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.utils
{
    public class GenreConverter
    {
        public static string FromEnum(Genre genre)
        {
            switch (genre)
            {
                case Genre.HORROR: return "horror";
                case Genre.COMEDY: return "comedy";
                case Genre.SCIFI:return "sci-fi";
                case Genre.FANTASY: return "fantasy";
                case Genre.ROMANCE:return "romance";
                case Genre.ADVENTURE:return "adventure";
                case Genre.NONFICTION:return "non-fiction";
                case Genre.SLICEOFLIFE:return "slice-of-life";
                case Genre.SUPERHEROES:return "superheroes";
                case Genre.HISTORY:return "history";
                default: return "-";
            }
        }

        public static Genre FromString(string str)
        {
            switch (str)
            {
                case "horror":return Genre.HORROR;
                case "comedy":return Genre.COMEDY;
                case "sci-fi":return Genre.SCIFI;
                case "romance":return Genre.ROMANCE;
                case "fantasy":return Genre.FANTASY;
                case "adventure":return Genre.ADVENTURE;
                case "history":return Genre.HISTORY;
                case "slice-of-life":return Genre.SLICEOFLIFE;
                case "superheroes":return Genre.SUPERHEROES;
                case "non-fiction":return Genre.NONFICTION;
                default:return Genre.HORROR;
            }
        }

    }
}
