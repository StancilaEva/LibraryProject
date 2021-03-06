using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.LendCommands
{
    public class ExtendLendCommand : IRequest<Lend>
    {
        public int IdLend { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
