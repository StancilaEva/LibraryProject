using Library.Application.DTOs;
using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.LendCommands
{
    public class CreateLendCommand : IRequest<LendDTO>
    {

        public LendDTO lendDTO;


    }
}
