using Library.Application.Exceptions;
using Library.Application.JwtTokenGeneration;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.RegistrationHandlers.CommandHandlers
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, string>
    {
        private readonly RegistrationService _identityService;
        private readonly IClientRepository _clientRepository;

        public LogInCommandHandler(RegistrationService identityService, IClientRepository clientRepository)
        {
            _identityService = identityService;
            _clientRepository = clientRepository;
        }

        public async Task<string> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            if (await _identityService.CheckIfUserAlreadyExists(request.Email))
            {
                if (await _identityService.CheckUserPassword(request.Email, request.Password))
                {
                    string identityId = await _identityService.GetProfileId(request.Email);
                    Client client = await _clientRepository.GetUserByIdentityId(identityId);
                    string result = await _identityService.GenerateJwtToken(client);
                    return result;
                }
                else
                {
                    throw new UserRegistrationException("Wrong password");
                }
            }
            else
            {
                throw new UserRegistrationException("No registered user with this email");
            }
        }
    }
}
