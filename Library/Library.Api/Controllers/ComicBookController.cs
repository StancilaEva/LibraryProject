using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.ComicBookDTOs;
using Library.Application.Commands.BookCommands;
using Library.Application.Queries;
using Library.Application.Queries.BookQueries;
using Library.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")] // o sa fie api/ComicBooks
    [ApiController]
    public class ComicBooksController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public ComicBooksController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetComicBooksPaging([FromQuery] ComicBookPaging comicBookPagingDTO)
        {
            var queryToSend = new GetComicBooksPageQuery()
            {
                Index = comicBookPagingDTO.Page,
                Genre = comicBookPagingDTO.Genre,
                Publisher = comicBookPagingDTO.Publisher,
                Order = comicBookPagingDTO.Order

            };
            var result = await _mediatr.Send(queryToSend);
            
            var mappedResult = _mapper.Map<List<ComicBook>, List<ComicBookSearchDTO>>(result.Item1);
            var recordCount = result.Item2;

            ComicBookPagingDTO comicBookPaging = new ComicBookPagingDTO()
            {
                ComicBooks = mappedResult,
                RecordCount = recordCount
            };

            return Ok(comicBookPaging);
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

            if(result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ComicBook,ComicBookDTO>(result);

            return Ok(mappedResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComicBookById(int id)
        {
            var commandToSend = new DeleteComicBookCommand()
            {
                Id = id
            };
            var result = await _mediatr.Send(commandToSend);

            if (result == null)
            {
                return NotFound();
            }

            var comicBookResult = _mapper.Map<ComicBook, ComicBookDTO>(result);
            
            return Ok(comicBookResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComicBookById(int id, [FromBody] ComicBookBodyDTO comicBookDTO)
        {
            var comicBook = _mapper.Map<ComicBookBodyDTO, ComicBook>(comicBookDTO);
            comicBook.Id = id;
            var commandToSend = new UpdateComicBookCommand()
            {
                ComicBook = comicBook
            };
            var result = await _mediatr.Send(commandToSend);

            if (result == null)
            {
                return NotFound();
            }

            var comicBookResult = _mapper.Map<ComicBook,ComicBookDTO>(result);
            return Ok(comicBookResult);
        }

        [HttpGet("Publishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            var querytoSend = new GetAllPublishersQuery();
            var result = await _mediatr.Send(querytoSend);
            if(result == null)
            {
                return NotFound();
            }
            var resultDTO = new PublishersDTO() { Publishers = result };

            return Ok(resultDTO);
        }

        [HttpGet("Genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var querytoSend = new GetAllGenresQuery();
            var result = await _mediatr.Send(querytoSend);
            if (result == null)
            {
                return NotFound();
            }

            var resultDTO = new GenresDTO() { Genres = result };

            return Ok(resultDTO);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchComics([FromQuery] Search searchValue)
        {
            if (String.IsNullOrEmpty(searchValue.SearchString))
            {
                return NoContent();
            }

            var querytoSend = new GetComicBookByNameQuery()
            {
                SearchString = searchValue.SearchString
            };
            var result = await _mediatr.Send(querytoSend);
            if (result.Count==0)
            {
                return NoContent();
            }

            var mappedResult = _mapper.Map<List<ComicBook>, List<ComicBookSearchDTO>>(result);

            return Ok(mappedResult);
        }


    }
}
