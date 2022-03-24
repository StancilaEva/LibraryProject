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
        public List<Lend> getAllLends();
        public void InsertLend(Lend lend);
    }
}
