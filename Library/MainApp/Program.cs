

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
using Library.Core.DesignPatterns.Observer;
using Library.Application.Queries;
using Library.Application.Handlers;
using Library.Application.Queries.ClientQueries;
using Library.Application.Commands.BookCommands.CreateBookCommand;
using Library.Application.DTOs;

namespace MainApp
{
    class MainApplication
    {

        static async Task Main(string[] args)
        {
            ComicBookRepository bookRepository = new ComicBookRepository();
            ClientRepository clientRepository = new ClientRepository();
            LendRepository lendRepository = new LendRepository();
            List<ComicBook> bookList = bookRepository.GetAllBooks();
            List<Client> clientList = clientRepository.GetAllClients();
            List<Lend> lendList = lendRepository.GetAllLends();
            lendRepository.InsertLend(new Lend(bookList[0], clientList[0], DateTime.Today, DateTime.Today.AddDays(7)));
            List<Lend> newLends = lendRepository.GetAllLends();
            foreach(Lend lend in newLends)
            {
                Console.WriteLine(lend.Book+" "+lend.Client);
            }

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
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMediatR(typeof(GetAllComicBooksQueryHandler));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var meditr = serviceProvider.GetRequiredService<IMediator>();
            var result = await meditr.Send(new GetAllComicBooksQuery());
            foreach(var item in result)
            {
                Console.WriteLine(item.Title);
            }
            var result2 = await meditr.Send(new GetClientLogInQuery()
            {
                Email = "stancilaeva@gmail.com",
                Password = "12345678"
            });
            Console.WriteLine(result2.UserName);
            var result3 = await meditr.Send(new CreateComicBookCommand()
            {
                BookDTO = new ComicBookDetailDTO(1,"someTitle","someAuthor","comedy",24)
                
            });
            Console.WriteLine(result3.Title + " " + result3.Publisher);
            Console.WriteLine(Guid.NewGuid());
            Console.WriteLine(Guid.NewGuid());
        }

    }
}
