using ComicBook.Api.DTOs;
using Library.Application.Commands.LendCommands;
using Library.Application.Queries.LendQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComicBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public LendsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("{clientId}/{comicId}")]
        public async Task<IActionResult> CreateLend(int clientId,int comicId,[FromBody]LendDTO lendDTO)
        {
            var commandToSend = new CreateLendCommand()
            {
                ComicId = comicId,
                UserId = clientId,
                StartDate = lendDTO.StartDate,
                EndDate = lendDTO.EndDate
            };
            var result = await _mediatR.Send(commandToSend);
            return CreatedAtAction(nameof(GetLendById),new { id = result.Id },result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLendById(int id)
        {
            var queryToSend = new GetLendByIdQuery()
            {
                Id = id
            };
            var result = await _mediatR.Send(queryToSend);
            return Ok(result);
        }
        
    }
}
