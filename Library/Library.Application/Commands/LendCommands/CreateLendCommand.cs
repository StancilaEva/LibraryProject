using Library.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.LendCommands
{
    public class CreateLendCommand : IRequest<Lend>
    {
        public Book Book{ get; set; }

        public Client Client{ get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}
