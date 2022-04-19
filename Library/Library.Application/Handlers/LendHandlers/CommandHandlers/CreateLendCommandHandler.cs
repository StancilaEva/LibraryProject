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
            List<Lend> lendedBooks = await _lendRepository.FilterLendsByBookAsync(request.ComicId);

            if (CheckIfBookIsAvailabe(lendedBooks,request.StartDate,request.EndDate))
            { 
                Lend lend = await _lendRepository.InsertLendAsync(request.UserId,request.ComicId,request.StartDate,request.EndDate);
                return lend;
            }
            else
            {
                throw new BookNotAvailableException("the book is not available in that time period");
            }
        }

        public bool CheckIfBookIsAvailabe(List<Lend> lendedBooks, DateTime startDate,DateTime endDate)
        {
           
            foreach (Lend lendThatContainsBook in lendedBooks)
            {
                if (BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, startDate) ||
                    BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, endDate))
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
