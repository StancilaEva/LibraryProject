using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.ErrorDTOs;
using Library.Api.DTOs.RegisterDTOs;
using Library.Api.DTOs.UserDTOs;
using Library.Application.Commands.ClientCommands;
using Library.Application.Commands.RegistrationCommands;
using Library.Application.Exceptions;
using Library.Application.Handlers.RegistrationHandlers.CommandHandlers;
using Library.Application.Queries.ClientQueries;
using Library.Core;
using Library.Core.Exceptions;
using Library.Infrastructure.Exceptions;
using MainApp;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IdentityController(IMapper mapper, IMediator mediatr)
        {
            _mapper = mapper;
            _mediator = mediatr;
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateClient([FromBody] SignUpDTO signUpDTO)
        {
            try
            {
                var commandToSend = new CreateUserCommand()
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

                return Ok(new TokenDTO
                {
                    Token = result,
                });
            }
            catch (InvalidEmailException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch (InvalidPasswordException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch (InvalidUsernameException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch (UserRegistrationException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch(CreateUserException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }

        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInCredentialsDTO logInDTO)
        {
            try
            {
                var command = new LogInCommand()
                {
                    Email = logInDTO.Email,
                    Password = logInDTO.Password
                };
                var result = await _mediator.Send(command);
                return Ok(new TokenDTO
                {
                    Token = result,
                });
            }catch(UserRegistrationException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
        }
    }
}
