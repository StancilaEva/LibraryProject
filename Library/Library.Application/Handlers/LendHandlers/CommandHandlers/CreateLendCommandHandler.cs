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

namespace Library.Application.Handlers.LendHandlers
{
    public class CreateLendCommandHandler : IRequestHandler<CreateLendCommand,Lend>
    {
        ILendRepository _lendRepository;

        public CreateLendCommandHandler(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public async Task<Lend> Handle(CreateLendCommand request, CancellationToken cancellationToken)
        {
           

            if (await IsValid(request.ComicId,request.StartDate,request.EndDate))
            { 
                Lend lend = await _lendRepository.InsertLendAsync(request.UserId,request.ComicId,request.StartDate,request.EndDate);

                lend = await _lendRepository.GetLendByIdAsync(lend.Id);
                return lend;
            }
            else
            {
                throw new BookNotAvailableException("this comic book is not available in that time period");
            }
        }

        public async Task<bool> IsValid(int comicId,DateTime startDate,DateTime endDate)
        {
            if(!(await CheckIfBookIsAvailable(comicId, startDate, endDate)))
            {
                throw new BookNotAvailableException("this comic book is not available in that time period");
            }
            if ((endDate - startDate).TotalDays > 14)
            {
                throw new LendDateNotValidException("lending time cant be more than two weeks");
            }
            return true;
        }

        public async Task<bool> CheckIfBookIsAvailable(int comicBookId, DateTime startDate,DateTime endDate)
        {
            if (await _lendRepository.FindIfComicHasBeenLentInThatTimePeriodAsync(comicBookId, startDate.Date,endDate.Date) == true) return false;
            return true;
        }

        
    }
}
