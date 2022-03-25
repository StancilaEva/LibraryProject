

using Library.Application;
using Library.Application.Exceptions;
using Library.Core;
using Library.Core.DesignPatterns.Singleton;
using Library.Core.FactoryDesignPattern.Factory;
using Library.Infrastructure;

namespace MainApp
{
    class MainApplication
    {
        //   static ArrayList bookArray;
        // static ArrayList clientArray;
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            ClientRepository clientRepository = new ClientRepository();
            LendRepository lendRepository = new LendRepository();
            List<Book> bookList = bookRepository.GetAllBooks();
            List<Client> clientList = clientRepository.GetAllClients();
            List<Lend> lendList = lendRepository.GetAllLends();
            lendRepository.InsertLend(new Lend(bookList[0], clientList[0], DateTime.Today, DateTime.Today.AddDays(7)));
            List<Lend> newLends = lendRepository.GetAllLends();
            foreach(Lend lend in newLends)
            {
                Console.WriteLine(lend.Book+" "+lend.Client);
            }

            LendBookService lendBookService = new LendBookService(lendRepository);
          


            BooksToFilesService booksToFilesService = new BooksToFilesService(bookRepository);
            booksToFilesService.WriteBooksToFile();
            List<Book> booksFromFile = booksToFilesService.RestoreBooksFromFile();
            booksFromFile.ForEach((book) =>Console.WriteLine(book));
            LibrarianSingleton librarianSingleton = LibrarianSingleton.GetInstance();
            librarianSingleton.MembershipFactory = new StandardMembershipFactory();
            LibraryMembership membership1 = librarianSingleton.MembershipFactory.Create();
            librarianSingleton.MembershipFactory = new PremiumMembershipFactory();
            LibraryMembership membership2 = librarianSingleton.MembershipFactory.Create();
            Console.WriteLine($"Abonamentul Standard are {membership1.Duration} zile\nAbonamentul Premium are {membership2.Duration} zile\n");
          


        }

    }
}
