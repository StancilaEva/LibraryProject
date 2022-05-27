using AutoMapper;
using Library.Api.DTOs.StatsDTO;
using Library.Api.DTOs.StatsDTOs;
using Library.Application.Exceptions;
using Library.Application.Queries.StatsQueries;
using Library.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public readonly IMapper _mapper;

        public StatsController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [HttpGet("MostBorrowedComics")]
        public async Task<IActionResult> MostBorrowedComics()
        {
            try
            {
                var queryToSend = new GetMostBorrowedComicQuery();

                var result = await _mediatR.Send(queryToSend);

                var statResult = _mapper.Map<List<ComicCountsDTO>>(result);

                return Ok(statResult);
            }
            catch(NotEnoughComicsException ex)
            {
                return NoContent();
            }
        }

        [HttpGet("MostReadGenres")]
        public async Task<IActionResult> MostReadGenres()
        {
            var queryToSend = new GetMostReadGenresQuery();

            var result = await _mediatR.Send(queryToSend);

            var statResult = _mapper.Map<List<GenreStatsDTO>>(result);

            return Ok(statResult);
        }

        [HttpGet("MostReadPublishers")]
        public async Task<IActionResult> MostReadPublishers()
        {
            var queryToSend = new GetMostReadPublishersQuery();

            var result = await _mediatR.Send(queryToSend);

            var statResult = _mapper.Map<List<PublisherStatsDTO>>(result);

            return Ok(statResult);
        }//GetUserWithMostComicsQuery

        [HttpGet("UserWithMostBorrowedComics")]
        public async Task<IActionResult> UserWithMostBorrowedComics()
        {
            try
            {
                var queryToSend = new GetUserWithMostComicsQuery();

                var result = await _mediatR.Send(queryToSend);

                var statResult = new UserStatsDTO()
                {
                    Username = result.Item1.Username,
                    Count = result.Item2
                };

                return Ok(statResult);
            }
            catch(NoLendsException ex)
            {
                return NoContent();
            }
        }

    }
}
