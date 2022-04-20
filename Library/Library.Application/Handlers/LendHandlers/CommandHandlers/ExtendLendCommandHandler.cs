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


            if (await isValid(lend, request.EndDate))
            {
                var result = await _lendRepository.ExtendLendAsync(lend, request.EndDate);

                return result;

            }
            else
                return null;
        }

        private async Task<bool> isValid(Lend lend, DateTime endDate)
        {
            if (lend == null)
                return false;
            if(lend.IsExtended == true)
            {
                throw new AlreadyExtendedException("this lend has already been extended");
            }
            if(lend.EndDate < System.DateTime.Now)
            {
                throw new ExtendDateNotValidException("the comic book has already been returned");
            }
            if (lend.EndDate > endDate)
            {
                throw new ExtendDateNotValidException("The extended date cannot be before the original end date");
            }
            if ((endDate - lend.EndDate).TotalDays > 7)
            {
                throw new ExtendDateNotValidException("You cannot extend the lending time of a comic by more than a week");
            }

            List<Lend> lends = await _lendRepository.FilterLendsByBookAsync(lend.Book.Id);

            if (CheckIfBookIsAvailabe(lends, endDate)==false)
            {
                throw new BookNotAvailableException("The comic book is not available in that time period");
            }
            return true;
        }

        public bool CheckIfBookIsAvailabe(List<Lend> lendedBooks, DateTime endDate)
        {

            foreach (Lend lendThatContainsBook in lendedBooks)
            {
                if (BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, endDate))
                {
                    return false;
                }

            }
            return true;
        }

        public bool BetweenTwoDates(DateTime start, DateTime end, DateTime date)
        {
            if (DateOnly.FromDateTime(start) <= DateOnly.FromDateTime(date) &&
                DateOnly.FromDateTime(end) >= DateOnly.FromDateTime(date))
                return true;
            else
                return false;
        }
    }
}
