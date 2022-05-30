using AutoMapper;
using Library.Api.Controllers;
using Library.Api.DTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.LendCommands;
using Library.Application.Queries.BookQueries;
using Library.Application.utils;
using Library.Core;
using Library.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace NUnitLibraryTests
{
    public class Tests
    {
        private Mock<IMediator> _mediator;
        private Mock<IMapper> _mapper;
        private ComicBooksController comicBookController;


        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public void LendingComicBookInThePastTest()
        {
          Assert.Throws<InvalidDateException>(()=>new Lend(new ComicBook(),new Client(),System.DateTime.Today.AddDays(-1),System.DateTime.Today));
        }

        [Test]
        public void StartDateAfterEndDateTest()
        {
            Assert.Throws<InvalidDateException>(() => new Lend(new ComicBook(), new Client(), System.DateTime.Today.AddDays(1), System.DateTime.Today));
        }
        
        [Test]
        public void InvalidEmailTest()
        {
            Assert.Throws<InvalidUserCredentialsException>(() => new Client("user1", "password1", new Address("street", "city", "county", 1), "someinvalidemail"));

        }

        [Test]
        public void InvalidUsernameTest()
        {
            Assert.Throws<InvalidUserCredentialsException>(() => new Client("", "password1", new Address("street", "city", "county", 1), "somevalidemail@gmail.com"));

        }

        [Test]
        public void ExtensionIsFalseOnNewLend()
        {
            Lend lend = new Lend(new ComicBook(), new Client(), System.DateTime.Today, System.DateTime.Today.AddDays(1));
            Assert.IsFalse(lend.IsExtended);
        }

        [TestCase("","city","county",1)]
        [TestCase("street","","county",1)]
        [TestCase("street", "city", "", 1)]
        public void EmptyAddressParametersTest(string street, string city, string county, int number)
        {
            Assert.Throws<ArgumentNullException>(() => new Address(street,city,county,number));
        }

        [Test]
        public async Task Get_Comic_By_Id_GetComicBookByIdIsCalled()
        {
            //Arrange
            _mediator
                .Setup(m => m.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(()=>CreateComicBook());
            //Act
            var controller = new ComicBooksController(_mediator.Object, _mapper.Object);

            var result = await controller.GetComicBookById(1);
           //var newResult = await result.ExecuteResultAsync()
            //Result
            Assert.IsInstanceOf<OkObjectResult>(result);
           
        }

        [Test]
        public async Task Check_Comic_By_Id_GetComicBookByIdIsCalled()
        {
            //Arrange
            _mediator
                .Setup(m => m.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => CreateComicBook());

            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ComicBook, ComicBookDTO>()
                 .ForMember(add => add.Title, opt => opt.MapFrom(comic => comic.Title))
                 .ForMember(x => x.Publisher, opt => opt.MapFrom(comic => comic.Publisher))
                 .ForMember(x => x.IssueNumber, opt => opt.MapFrom(comic => comic.IssueNumber))
                 .ForMember(x => x.Cover, opt => opt.MapFrom(comic => comic.Cover))
                 .ForMember(x => x.Genre, opt => opt.MapFrom(comic => GenreConverter.FromEnum(comic.Genre)))
                );
            Mapper map = new Mapper(config);
            //Act
            var controller = new ComicBooksController(_mediator.Object,map);

            var result = await controller.GetComicBookById(1);
            //var newResult = await result.ExecuteResultAsync()
            //Result

            var okObject = result as OkObjectResult;
            Assert.IsInstanceOf<OkObjectResult>(okObject);
            var body = okObject.Value;
            Assert.IsInstanceOf<ComicBookDTO>(body);
            var comic = body as ComicBookDTO;
            Assert.AreEqual(1, comic.Id);
        }


        //[Test]
        //public async Task Check_OverLapping_Lend_CreateLend()
        //{
        //    //Arrange
        //    _mediator
        //        .Setup(m => m.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(() => new Lend(1));

        //    var config = new MapperConfiguration(cfg =>
        //            cfg.CreateMap<Lend, LendResultDTO>()
        //        .ForMember(add => add.ComicBookId, opt => opt.MapFrom(x => x.Book.Id))
        //         .ForMember(add => add.ComicBookTitle, opt => opt.MapFrom(x => x.Book.Title))
        //          .ForMember(x => x.ComicBookCover, opt => opt.MapFrom(x => x.Book.Cover))
        //          .ForMember(add => add.StartDate, opt => opt.MapFrom(x => x.StartDate))
        //           .ForMember(add => add.EndDate, opt => opt.MapFrom(x => x.EndDate))
        //           .ForMember(add => add.LendId, opt => opt.MapFrom(x => x.Id))
        //           .ForMember(add => add.ClientId, opt => opt.MapFrom(x => x.Client.Id))
        //           .ForMember(add => add.Extended, opt => opt.MapFrom(x => x.IsExtended))
        //        );
        //    Mapper map = new Mapper(config);
        //    //Act
        //    var controller = new ComicBooksController(_mediator.Object, map);

        //    var result = await controller.GetComicBookById(1);
        //    //var newResult = await result.ExecuteResultAsync()
        //    //Result

        //    var okObject = result as OkObjectResult;
        //    Assert.IsInstanceOf<OkObjectResult>(okObject);
        //    var body = okObject.Value;
        //    Assert.IsInstanceOf<ComicBookDTO>(body);
        //    var comic = body as ComicBookDTO;
        //    Assert.AreEqual(1, comic.Id);

        //}



        [Test]
        public async Task Invalid_ComicBook_GetComicBookByIdIsCalled()
        {
            //Arrange
            _mediator
                .Setup(m => m.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            
            //Act
            var controller = new ComicBooksController(_mediator.Object, _mapper.Object);

            var result = await controller.GetComicBookById(-1);
            //Result

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        

        [Test]
        public async Task Create_Lend_CreateLendCommandIsCalled()
        {
            //Arrange

            _mediator
                .Setup(m => m.Send(It.IsAny<CreateLendCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(()=>CreateListOfLends());
            //Act

            var controller = new LendsController(_mediator.Object, _mapper.Object);
            

            var result = await controller.CreateLend(1,1,new LendDTO()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });
            
            //Result

            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }



        private ComicBook CreateComicBook()
        {
            return new ComicBook(1, "title", "publisher", Genre.COMEDY, 1, "cover");
        }

        private Lend CreateListOfLends()
        {
            var comic = new ComicBook(1, "title", "publisher", Genre.COMEDY, 1, "cover");
            var client = new Client(1,"user1", new Address("street", "city", "county", 1), "somevalidemail@gmail.com");
            return new Lend(comic, client, DateTime.Today, DateTime.Today.AddDays(14));
        }

    }
}