using ComicBook.Api.DTOs;
using Library.Application.Commands.BookCommands;
using Library.Application.Queries;
using Library.Application.Queries.BookQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComicBook.Api.Controllers
{
    [Route("api/[controller]")] // o sa fie api/ComicBooks
    [ApiController]
    public class ComicBooksController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ComicBooksController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet]
        public async Task<IActionResult> GetComicBooksPaging([FromQuery] ComicBookPagingDTO comicBookPagingDTO)
        {
            var queryToSend = new GetComicBooksPageQuery()
            {
                Index = comicBookPagingDTO.Page,
                Genre = comicBookPagingDTO.Genre,
                Publisher = comicBookPagingDTO.Publisher,
                Order = comicBookPagingDTO.Order

            };
            var result = await _mediatr.Send(queryToSend);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetComicBookById(int id)
        {
            var commandToSend = new GetComicBookByIdQuery()
            {
                Id = id,
            };
            var result = await _mediatr.Send(commandToSend);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComicBookById(int id)
        {
            var commandToSend = new DeleteComicBookCommand()
            {
                Id = id
            };
            var result = await _mediatr.Send(commandToSend);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComicBookById(int id,[FromBody]ComicBookDTO comicBookDTO)
        {
            var commandToSend = new UpdateComicBookCommand()
            {
                Id = id,
                Title = comicBookDTO.Title,
                Publisher = comicBookDTO.Publisher,
                IssueNumber = comicBookDTO.IssueNumber,
                Genre = comicBookDTO.Genre,
                Cover = comicBookDTO.Cover,
            };
            var result = await _mediatr.Send(commandToSend);

            return Ok(result);
        }


    }
}
