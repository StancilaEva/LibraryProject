using Library.Application;
using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class LendRepository : ILendRepository
    {
        List<Lend> lendList;
        public LendRepository()
        {
            lendList = new List<Lend>();
        }

        public List<Lend> getAllLends()
        {
            return lendList;
        }
        public void InsertLend(Lend lend)
        {
            lendList.Add(lend);
        }
    }
}
