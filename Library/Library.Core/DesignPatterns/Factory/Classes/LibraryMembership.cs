using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public abstract class LibraryMembership
    {
        private readonly int duration;
        public int Duration { get { return duration; } }
        public List<ComicBook> BorrowedBooks { get; set; }

        protected LibraryMembership(int duration)
        {
            this.duration = duration;
            BorrowedBooks = new List<ComicBook>();
        }
    }
}
