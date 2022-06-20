using Library.Core;
using Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitLibraryTests.helpers
{
    public class Utilities
    {
		public static void InitializeDbForTests(LibraryContext db)
		{
			
			var comic1 = new ComicBook("title1", "publisher1", Genre.ROMANCE, 2, "cover1");
			var comic2 = new ComicBook("title2", "publisher2", Genre.ROMANCE, 2, "cover2");
			var comic3 = new ComicBook("title3", "publisher3", Genre.ROMANCE, 2, "cover3");

			db.ComicBooks.AddRange(comic1, comic2, comic3);

			var client1 = new Client("identityId1","user1", new Address("street1", "city1", "county1", 1),"user1@email.com");
			var client2 = new Client("identityId2","user2", new Address("street2", "city2", "county2", 2), "user2@email.com");

			db.Clients.AddRange(client1, client2);

			var lend1 = new Lend(comic1, client1, DateTime.Now.AddDays(1).Date, DateTime.Now.AddDays(7).Date);
			var lend2 = new Lend(comic1, client1, DateTime.Now.AddDays(10).Date, DateTime.Now.AddDays(12).Date);

			db.Lends.AddRange(lend1,lend2);
			db.SaveChanges();
		}
	}
}
