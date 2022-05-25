using AutoMapper;
using Library.Api.DTOs.StatsDTO;
using Library.Api.DTOs.StatsDTOs;
using Library.Application.Queries.StatsQueries;
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
            var queryToSend = new GetMostBorrowedComicQuery();
            
            var result = await _mediatR.Send(queryToSend);

            var statResult = _mapper.Map<List<ComicCountsDTO>>(result);

            return Ok(statResult);
        }

        [HttpGet("MostReadGenres")]
        public async Task<IActionResult> MostReadGenres()
        {
            var queryToSend = new GetMostReadGenresQuery();

            var result = await _mediatR.Send(queryToSend);

            var statResult = _mapper.Map<List<GenreDTO>>(result);

            return Ok(statResult);
        }
    }
}
