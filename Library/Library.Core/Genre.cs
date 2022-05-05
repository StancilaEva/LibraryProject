using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public enum Genre
    {
        [Display(Name = "horror")]
        HORROR,
        [Display(Name = "comedy")]
        COMEDY,
        [Display(Name = "sci-fi")]
        SCIFI,
        [Display(Name = "fantasy")]
        FANTASY,
        [Display(Name = "romance")]
        ROMANCE,
        [Display(Name = "adventure")]
        ADVENTURE,
        [Display(Name = "history")]
        HISTORY,
        [Display(Name = "slice-of-life")]
        SLICEOFLIFE,
        [Display(Name = "superheroes")]
        SUPERHEROES,
        [Display(Name = "non-fiction")]
        NONFICTION
    }
}
