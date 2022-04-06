using Library.Application.Commands.LendCommands;
using Library.Application.DTOs;
using Library.Application.Exceptions;
using Library.Core;
using Library.Infrastructure;
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
        public CreateLendCommandHandler()
        {
            this._lendRepository = new LendRepository();
        }
        //SCHIMBA CAND POTI
        public Task<Lend> Handle(CreateLendCommand request, CancellationToken cancellationToken)
        {
            Lend lend = null;
            if (CheckIfBookIsAvailabe(request.LendDTO.BookId,request.LendDTO.StartDate,request.LendDTO.EndDate))
            {
                
                _lendRepository.InsertLend(lend);
                return Task.FromResult(lend);
            }
            else
            {
                throw new BookNotAvailableException("the book is not available in that time period");
            }
        }

        public bool CheckIfBookIsAvailabe(String id,DateTime startDate,DateTime endDate)
        {
            List<Lend> lendedBooks = _lendRepository.FilterLendsByBook(id);
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
            if (DateOnly.FromDateTime(start) < DateOnly.FromDateTime(date) &&
                DateOnly.FromDateTime(end) > DateOnly.FromDateTime(date))
                return true;
            else
                return false;
        }

        
    }
}
