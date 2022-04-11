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
                case "fantasu":return Genre.FANTASY;
                default:return Genre.HORROR;
            }
        }

    }
}
