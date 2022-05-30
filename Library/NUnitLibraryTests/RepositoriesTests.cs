using AutoMapper;
using Library.Api.Controllers;
using Library.Application.Commands.LendCommands;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
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
    internal class RepositoriesTests
    {
        private Mock<IMediator> _mediator;
        private Mock<ILendRepository> _lendRepository;
        private ComicBooksController comicBookController;


        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
        }

        [Test]
        public async Task Check_Comic_By_Id_GetComicBookByIdIsCalled()
        {
            ////Arrange
            //_mediator
            //    .Setup(m => m.Send(It.IsAny<CreateLendCommand>(), It.IsAny<CancellationToken>())).Returns(async (CreateLendCommand c, CancellationToken token)
            //                                => await .Handle
            //                               (new GetBlockedCustomersAndGroupsQuery { Active = q.Active }, token));

            //var config = new MapperConfiguration(cfg =>
            //        cfg.CreateMap<ComicBook, ComicBookDTO>()
            //     .ForMember(add => add.Title, opt => opt.MapFrom(comic => comic.Title))
            //     .ForMember(x => x.Publisher, opt => opt.MapFrom(comic => comic.Publisher))
            //     .ForMember(x => x.IssueNumber, opt => opt.MapFrom(comic => comic.IssueNumber))
            //     .ForMember(x => x.Cover, opt => opt.MapFrom(comic => comic.Cover))
            //     .ForMember(x => x.Genre, opt => opt.MapFrom(comic => GenreConverter.FromEnum(comic.Genre)))
            //    );
            //Mapper map = new Mapper(config);
            ////Act
            //var controller = new ComicBooksController(_mediator.Object, map);

            //var result = await controller.GetComicBookById(1);
            ////var newResult = await result.ExecuteResultAsync()
            ////Result

            //var okObject = result as OkObjectResult;
            //Assert.IsInstanceOf<OkObjectResult>(okObject);
            //var body = okObject.Value;
            //Assert.IsInstanceOf<ComicBookDTO>(body);
            //var comic = body as ComicBookDTO;
            Assert.AreEqual(1, comic.Id);
        }

        private List<Lend> getLendList()
        {
            return new List<Lend>()
            {
                new Lend(1,2,DateTime.Now,DateTime.Now.AddDays(7))
            };
        }
    }
}
