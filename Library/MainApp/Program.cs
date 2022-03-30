﻿

using Library.Application;
using Library.Application.Commands.ClientCommands;
using Library.Core;
using Library.Core.DesignPatterns.Singleton;
using Library.Core.FactoryDesignPattern.Factory;
using Library.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Library.Core.DesignPatterns.Proxy;
using Library.Core.DesignPatterns.Decorator;

namespace MainApp
{
    class MainApplication
    {
        //   static ArrayList bookArray;
        // static ArrayList clientArray;
        static  void Main(string[] args)
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

            
          


            BooksToFile booksToFilesService = new BooksToFile(bookRepository);
            booksToFilesService.WriteBooksToFile();
            List<Book> booksFromFile = booksToFilesService.RestoreBooksFromFile();
            booksFromFile.ForEach((book) =>Console.WriteLine(book));
            LibrarianSingleton librarianSingleton = LibrarianSingleton.GetInstance();
            librarianSingleton.MembershipFactory = new StandardMembershipFactory();
            LibraryMembership membership1 = librarianSingleton.MembershipFactory.Create();
            librarianSingleton.MembershipFactory = new PremiumMembershipFactory();
            LibraryMembership membership2 = librarianSingleton.MembershipFactory.Create();
            Console.WriteLine($"Abonamentul Standard are {membership1.Duration} zile\nAbonamentul Premium are {membership2.Duration} zile\n");
            LibraryVIPServicesProxy libraryVIPServicesProxy = new LibraryVIPServicesProxy(new LibraryVIPServices());
            libraryVIPServicesProxy.GetInternetAccess(membership1);
            libraryVIPServicesProxy.GetInternetAccess(membership2);

            IMembership membership = new DefaultMembership();
            membership = new ComputerAccess(membership);
            membership = new InternetAccess(membership);
            Console.WriteLine(membership.GetAccess() + " " + membership.GetCost());
            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddMediatR(typeof(SignUpCommand));
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var meditr = serviceProvider.GetRequiredService<IMediator>();
            //await meditr.Send()
        }

    }
}
