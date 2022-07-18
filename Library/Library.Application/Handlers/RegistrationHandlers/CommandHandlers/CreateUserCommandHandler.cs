using Library.Application.Commands.RegistrationCommands;
using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Application.JwtTokenGeneration;
using Library.Application.Options;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MainApp;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Application.Handlers.RegistrationHandlers.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private RegistrationService  _identityService;
        private readonly IUserRegistrator _register;

        public CreateUserCommandHandler(RegistrationService identityService, IUserRegistrator register)
        {
            _identityService = identityService;
            _register = register;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!await _identityService.CheckIfUserAlreadyExists(request.Email))
            {
                Client client = await _register.InsertUserInTheDatabase(request.Email, request.Username, request.Password, new Address(request.Street, request.City, request.County, request.Number));
                if (client != null)
                {
                    var token = await _identityService.GenerateJwtToken(client);
                    return token;
                }
                else throw new UserRegistrationException("Something went wrong");
            }
            else
            {
                throw new UserRegistrationException("User already exists");
            }
        }
    }
}
