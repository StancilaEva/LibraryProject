
using ComicBook.Api.DTOs;
using Library.Application.Commands.ClientCommands;
using Library.Application.Queries.ClientQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComicBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody]SignUpDTO signUpDTO)
        {
            var commandToSend = new SignUpCommand()
            {
                Username = signUpDTO.Username,
                Password = signUpDTO.Password,
                Email = signUpDTO.Email,
                Street = signUpDTO.Street,
                City = signUpDTO.City,
                County = signUpDTO.County,
                Number = signUpDTO.Number
            };
            var result = await _mediator.Send(commandToSend);

            //return CreatedAtAction(nameof(GetClientId),new { id = result.Id },result);
            return Ok(result);  
        }

        [HttpGet]
        public async Task<IActionResult> LogInClient([FromBody]LogInCredentialsDTO logInDTO)
        {
            var queryToSend = new GetClientLogInQuery()
            {
                Email = logInDTO.Email,
                Password = logInDTO.Password
            };
            var result = _mediator.Send(queryToSend);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClientId(int id)
        {
            var queryToSend = new GetClientByIdQuery()
            {
                Id = id
            };
            var result = await _mediator.Send(queryToSend);
            return Ok(result);
        }
        
        
    }
}
