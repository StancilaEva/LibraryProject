using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.ErrorDTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.ClientCommands;
using Library.Application.Commands.LendCommands;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public ClientController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediatr = mediatr;
        }

        [HttpPatch("Address")]
        public async Task<IActionResult> ChangeAddress([FromBody] AddressDTO addressModel)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var id = Int32.Parse(identity.FindFirst("UserId").Value);
                    var addressToSend = _mapper.Map<Address>(addressModel);
                    var commandToSend = new UpdateAddressCommand()
                    {
                        Id = id,
                        NewAddress = addressToSend
                    };

                    var result = await _mediatr.Send(commandToSend);

                    return Ok(result);
                }
                else
                {
                    return Unauthorized();
                }
            }catch(ArgumentNullException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }

        }

        [HttpGet("Address")]
        public async Task<IActionResult> GetAddress()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = Int32.Parse(identity.FindFirst("UserId").Value);
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
            else
            {
                return Unauthorized();
            }

        }

        
    }
}
