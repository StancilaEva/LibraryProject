

using Library.Application;
using Library.Application.Exceptions;
using Library.Core;
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
            List<Lend> lendList = lendRepository.getAllLends();
            lendRepository.InsertLend(new Lend(bookList[0], clientList[0], DateTime.Today, DateTime.Today.AddDays(7)));
            List<Lend> newLends = lendRepository.getAllLends();
            foreach(Lend lend in newLends)
            {
                Console.WriteLine(lend.Book+" "+lend.Client);
            }

            LendBookService lendBookService = new LendBookService(lendRepository);
            //try
            //{
            //    lendBookService.LendBookToClient(bookList[0], clientList[1], DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));
            //}catch(BookNotAvailableException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            BooksToFilesService booksToFilesService = new BooksToFilesService(bookRepository);
            booksToFilesService.WriteBooksToFile();
            List<Book> booksFromFile = booksToFilesService.RestoreBooksFromFile();
            booksFromFile.ForEach((book) =>Console.WriteLine(book));    

            IMembershipFactory factory = new StandardMembershipFactory();
            LibraryMembership membership1 = factory.Create();
            factory = new PremiumMembershipFactory();
            LibraryMembership membership2 = factory.Create();
            Console.WriteLine($"Abonamentul Standard are {membership1.Duration} zile\nAbonamentul Premium are {membership2.Duration} zile\n");


        }

    }
}
