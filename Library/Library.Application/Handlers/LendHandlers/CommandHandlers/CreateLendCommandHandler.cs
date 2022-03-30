using Library.Application.Commands.LendCommands;
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


        public CreateLendCommandHandler(ILendRepository lendRepository)
        {
            this._lendRepository = new LendRepository();
        }

        public Task<Lend> Handle(CreateLendCommand request, CancellationToken cancellationToken)
        {
            //Lend lend = new Lend(request.Book, request.Client, request.StartDate, request.EndDate);
            //if (CheckIfBookIsAvailabe(lend))
            //{
            //    _lendRepository.InsertLend(lend);
            //    return Task.FromResult(lend);
            //}
            //else
            //{
            //    throw new BookNotAvailableException("the book is not available in that time period");
            //}
            throw new NotImplementedException();
        }

        public bool CheckIfBookIsAvailabe(Lend lend)
        {
            List<Lend> lendedBooks = _lendRepository.FilterLendsByBook(lend.Book.Id);
            foreach (Lend lendThatContainsBook in lendedBooks)
            {
                if (BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, lend.StartDate) ||
                    BetweenTwoDates(lendThatContainsBook.StartDate, lendThatContainsBook.EndDate, lend.EndDate))
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
