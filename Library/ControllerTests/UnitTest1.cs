using AutoMapper;
using Library.Api.Controllers;
using Library.Api.DTOs;
using Library.Application.Queries.BookQueries;
using MediatR;

using Moq;
using NUnit.Framework;
using System.Threading;

namespace ControllerTests
{
    public class Tests
    {
        //private Mock<IMediator> _mediator = new Mock<IMediator>();
        //private Mock<IMapper> _mapper = new Mock<IMapper>();
        //private ComicBooksController comicBookController;



        //public void InitialTestSetUp()
        //{
        //    _mediator = new Mock<IMediator>();
        //    _mapper = new Mock<IMapper>();
        //    comicBookController = new ComicBooksController(_mediator.Object,_mapper.Object);
        //}

        ////[Fact]
        ////public async void Get_Comics_Paging_GetComicBookPagingIsCalled()
        ////{
        ////    _mediator
        ////        .Setup(m=>m.Send(It.IsAny<GetComicBooksPageQuery>(),It.IsAny<CancellationToken>()))
        ////        .Verifiable();
        ////    await comicBookController.GetComicBooksPaging();
        ////}
        //[Test]
        //public async void Get_Comic_By_Id_GetComicBookByIdIsCalled()
        //{
        //    //Arrange
        //    _mediator
        //        .Setup(m => m.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()))
        //        .Verifiable();
        //    //Act
        //    var controller = new ComicBooksController(_mediator.Object,_mapper.Object);

        //    var result = await controller.GetComicBookById(1);
        //    //Result

        //    Assert.IsInstanceOf<ComicBookDTO>(result);
        //    //_mediator.Verify(x => x.Send(It.IsAny<GetComicBookByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        //}
    }
}