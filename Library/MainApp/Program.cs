

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
using System.Drawing;
using Library.Infrastructure.Data;
using Library.Application.Handlers.BookHandlers;
using Microsoft.EntityFrameworkCore;
using Library.Core.Interfaces.RepositoryInterfaces;

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


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Title);
            //}
            //var result2 = await meditr.Send(new GetClientLogInQuery()
            //{
            //    Email = "stancilaeva@gmail.com",
            //    Password = "12345678"
            //});

            //Console.WriteLine(result2.UserName);
            //var result3 = await meditr.Send(new CreateComicBookCommand()
            //{
            //    BookDTO = new ComicBookDetailDTO(1, "someTitle", "someAuthor", "comedy", 24)

            //});
            //Console.WriteLine(result3.Title + " " + result3.Publisher);//C:\Users\eva.stancila\Desktop\poze_benzi_desenate

            //Client client = context.Clients.FirstOrDefault(client => client.Id == 2);
            ////List<Lend> lends = new List<Lend>
            ////{
            ////    new Lend(comicBook,client,DateTime.Now,DateTime.Now.AddDays(7))

            ////};
            //Lend lend = new Lend(comicBook, client, DateTime.Now.AddDays(14), DateTime.Now.AddDays(28));
            //context.Lends.Add(lend);
            //context.SaveChanges();
            //LibraryContext lb = new LibraryContext();
            //Address book = lb.Addresses.FirstOrDefault(x => x.Id == 5);
            //lb.Addresses.Remove(book);
            //lb.SaveChanges();


        }

    }
}
