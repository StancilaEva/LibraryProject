using Library.Application.Commands.LendCommands;
using Library.Application.Exceptions;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.LendHandlers.CommandHandlers
{
    public class ExtendLendCommandHandler : IRequestHandler<ExtendLendCommand, Lend>
    {
        ILendRepository _lendRepository;

        public ExtendLendCommandHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<Lend> Handle(ExtendLendCommand request, CancellationToken cancellationToken)
        {
            Lend lend = await _lendRepository.GetLendByIdAsync(request.IdLend);


            if (await isValid(lend, request.EndDate,request.UserId))
            {
                var result = await _lendRepository.ExtendLendAsync(lend, request.EndDate);

                return result;

            }
            else
                return null;
        }

        private async Task<bool> isValid(Lend lend, DateTime endDate,int userId)
        {
            if (lend == null)
                return false;
            if(lend.IsExtended == true)
            {
                throw new AlreadyExtendedException("this lend has already been extended");
            }
            if(lend.EndDate < System.DateTime.Now)
            {
                throw new LendDateNotValidException("this comic book has already been returned");
            }
            if (lend.EndDate > endDate)
            {
                throw new LendDateNotValidException("The extended date cannot be before the original end date");
            }
            if ((endDate - lend.EndDate).TotalDays > 7)
            {
                throw new LendDateNotValidException("You cannot extend the lending time of a comic by more than a week");
            }
            if (await CheckIfBookIsAvailabe(lend, endDate))
            {
                throw new LendDateNotValidException("The comic book is not available in that time period");
            }
            if(lend.ClientId != userId)
            {
                throw new UnauthorizedAccessException("You can only extend the time period for one of your borrowed comics");
            }
            return true;
        }


        //am cautat cu any daca exista un imprumut care sa fie in perioada cand dorim sa extindem si noi imprumutul => nu putem 
        private async Task<bool> CheckIfBookIsAvailabe(Lend lend, DateTime endDate)
        {
            return await _lendRepository.FindOverlapInLendedComicsAsync(lend, endDate.Date);
           
        }

        
    }
}
