using AutoMapper;
using Library.Api.Controllers;
using Library.Api.DTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.LendCommands;
using Library.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitLibraryTests
{
    public class LendIntegrationTests
    {
        private Mock<IMediator> _mediator;
        private IMapper _mapper;
        private ComicBooksController comicBookController;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Lend, LendResultDTO>()
                    .ForMember(add => add.ComicBookId, opt => opt.MapFrom(x => x.Book.Id))
                 .ForMember(add => add.ComicBookTitle, opt => opt.MapFrom(x => x.Book.Title))
                  .ForMember(x => x.ComicBookCover, opt => opt.MapFrom(x => x.Book.Cover))
                  .ForMember(add => add.StartDate, opt => opt.MapFrom(x => x.StartDate))
                   .ForMember(add => add.EndDate, opt => opt.MapFrom(x => x.EndDate))
                   .ForMember(add => add.LendId, opt => opt.MapFrom(x => x.Id))
                   .ForMember(add => add.ClientId, opt => opt.MapFrom(x => x.Client.Id))
                   .ForMember(add => add.Extended, opt => opt.MapFrom(x => x.IsExtended))
                );
            _mapper = new Mapper(config);
        }

        [Test]
        public async Task Create_Lend_CreateLendCommandIsCalled()
        {
            //Arrange

            _mediator
                .Setup(m => m.Send(It.IsAny<CreateLendCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => CreateLend());
            //Act

            var controller = new LendsController(_mediator.Object, _mapper);


            var result = await controller.CreateLend(1, 1, new LendDTO()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });

            //Result

            Assert.IsInstanceOf<CreatedAtActionResult>(result);
        }




        private Lend CreateLend()
        {
            var comic = new ComicBook(1, "title", "publisher", Genre.COMEDY, 1, "cover");
            var client = new Client(1, "user1", new Address("street", "city", "county", 1), "somevalidemail@gmail.com");
            return new Lend(comic, client, DateTime.Today, DateTime.Today.AddDays(14));
        }

    }
}
