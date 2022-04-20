

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
using Library.Infrastructure.Data;
using Library.Core.Interfaces.RepositoryInterfaces;
using Library.Application.Queries.ClientQueries;
using Microsoft.EntityFrameworkCore;

namespace MainApp
{
    class MainApplication
    {

        static async Task Main(string[] args)
        {

            //LibrarianSingleton librarianSingleton = LibrarianSingleton.GetInstance();
            //librarianSingleton.MembershipFactory = new StandardMembershipFactory();
            //LibraryMembership membership1 = librarianSingleton.MembershipFactory.Create();
            //librarianSingleton.MembershipFactory = new PremiumMembershipFactory();
            //LibraryMembership membership2 = librarianSingleton.MembershipFactory.Create();
            //Console.WriteLine($"Abonamentul Standard are {membership1.Duration} zile\nAbonamentul Premium are {membership2.Duration} zile\n");
            //LibraryVIPServicesProxy libraryVIPServicesProxy = new LibraryVIPServicesProxy(new LibraryVIPServices());
            //libraryVIPServicesProxy.GetInternetAccess(membership1);
            //libraryVIPServicesProxy.GetInternetAccess(membership2);

            //IMembership membership = new DefaultMembership();


            //membership = new ComputerAccess(membership);
            // membership = new InternetAccess(membership);
            // Console.WriteLine(membership.GetAccess() + " " + membership.GetCost());
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMediatR(typeof(GetAllComicBooksQueryHandler));
            serviceCollection.AddDbContext<LibraryContext>();
            serviceCollection.AddTransient(typeof(IBookRepository), typeof(ComicBookRepository));
            serviceCollection.AddTransient(typeof(IClientRepository), typeof(ClientRepository));
            serviceCollection.AddTransient(typeof(ILendRepository), typeof(LendRepository));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var meditr = serviceProvider.GetRequiredService<IMediator>();
            var result = await meditr.Send(new GetAllComicBooksQuery());
            foreach(var book in result)
            {
                Console.WriteLine(book.Title+"\n\n\n"+book.Cover);
            }

          


        }

    }
}
