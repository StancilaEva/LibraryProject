using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface ILendRepository
    {
        public List<Lend> GetAllLends();
        public void InsertLend(Lend lend);
        public List<Lend> FilterLendsByBook(string bookId);
    }
}
