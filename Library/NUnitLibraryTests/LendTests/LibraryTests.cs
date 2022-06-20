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
            Assert.Throws<InvalidUserCredentialsException>(() => new Client("user1", new Address("street", "city", "county", 1), "someinvalidemail"));

        }

        [Test]
        public void InvalidUsernameTest()
        {
            Assert.Throws<InvalidUserCredentialsException>(() => new Client("", new Address("street", "city", "county", 1), "somevalidemail@gmail.com"));

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

    }
}