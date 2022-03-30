﻿using Library.Application.Commands.ClientCommands.SignUpUserCommand;
using Library.Application.DTOs;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.ClientCommands
{
    public class SignUpCommand : IRequest<LogInDTO>
    {
        public SignUpDTO SignUpDTO { get; set; }

    }
}
