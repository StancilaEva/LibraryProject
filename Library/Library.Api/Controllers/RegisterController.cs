
using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.UserDTOs;
using Library.Application.Commands.ClientCommands;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using Library.Core.Exceptions;
using MainApp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public RegisterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInCredentialsDTO logInDTO)
        {
            try
            {
                var queryToSend = new GetClientLogInQuery()
                {
                    Email = logInDTO.Email,
                    Password = logInDTO.Password
                };
                var result = await _mediator.Send(queryToSend);

                if (result == null)
                {
                    return NotFound();
                }

                var userResult = _mapper.Map<UserDetailDTO>(result);

                return CreatedAtAction(nameof(GetClientId), new { id = result.Id }, userResult);
            }
            catch(NonExistentUserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(WrongPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateClient([FromBody] SignUpDTO signUpDTO)
        {
            try
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
                var userResult = _mapper.Map<UserDetailDTO>(result);

                return CreatedAtAction(nameof(GetClientId), new { id = result.Id }, userResult);
            }
            catch(InvalidEmailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidUsernameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EmailAlreadyInUseException ex)
            {
                return BadRequest(ex.Message);
            }
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

            if (result == null)
            {
                return NotFound();
            }

            var registrationDTO = _mapper.Map<UserDetailDTO>(result);

            return Ok(registrationDTO);
        }


    }
}
