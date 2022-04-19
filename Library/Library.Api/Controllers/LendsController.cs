
using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.LendCommands;
using Library.Application.Exceptions;
using Library.Application.Queries.LendQueries;
using Library.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LendsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public readonly IMapper _mapper;

        public LendsController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [HttpPost("{clientId}/comicbook/{comicId}")]
        public async Task<IActionResult> CreateLend(int clientId, int comicId, [FromBody] LendDTO lendDTO)
        {
            try
            {
                var commandToSend = new CreateLendCommand()
                {
                    ComicId = comicId,
                    UserId = clientId,
                    StartDate = lendDTO.StartDate,
                    EndDate = lendDTO.EndDate
                };
                var result = await _mediatR.Send(commandToSend);
                var lendResult = _mapper.Map<LendResultDTO>(result);

                return CreatedAtAction(nameof(GetLendById), new { id = result.Id }, lendResult);
            }
            catch(InvalidDateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (BookNotAvailableException ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLendById(int id)
        {
            var queryToSend = new GetLendByIdQuery()
            {
                Id = id
            };
            var result = await _mediatR.Send(queryToSend);

            var lendResult = _mapper.Map<LendResultDTO>(result);

            return Ok(lendResult);
        }

    }
}
