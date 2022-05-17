using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.ClientCommands;
using Library.Application.Commands.LendCommands;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public ClientController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediatr = mediatr;
        }

        [HttpPatch("{id}/Address")]
        public async Task<IActionResult> ChangeAddress([FromBody] AddressDTO addressModel, int id)
        {
            var addressToSend = _mapper.Map<Address>(addressModel);
            var commandToSend = new UpdateAddressCommand()
            {
                Id = id,
                NewAddress = addressToSend
            };

            var result = await _mediatr.Send(commandToSend);

            return Ok(result);

        }

        [HttpGet("{id}/Address")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var queryToSend = new GetClientAddressQuery()
            {
                Id = id
            };
            var result = await _mediatr.Send(queryToSend);

            if (result == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<AddressDTO>(result);

            return Ok(mappedResult);

        }

        [HttpGet("{id}/Lends")]
        public async Task<IActionResult> GetLends(int id)
        {
            var queryToSend = new GetClientLendsQuery()
            {
                IdClient = id
            };
            var result = await _mediatr.Send(queryToSend);

            if (result.Count==0)
            {
                return NoContent();
            }

            var mappedResult = _mapper.Map<List<LendResultDTO>>(result);

            return Ok(mappedResult);
        }
    }
}
