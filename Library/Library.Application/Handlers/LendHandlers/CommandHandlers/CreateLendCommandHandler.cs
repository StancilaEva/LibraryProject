using Library.Application.Commands.LendCommands;
using Library.Application.DTOs;
using Library.Application.Exceptions;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
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
            _lendRepository = lendRepository;
        }

        public async Task<Lend> Handle(CreateLendCommand request, CancellationToken cancellationToken)
        {
            List<Lend> lendedBooks = await _lendRepository.FilterLendsByBookAsync(request.LendDTO.BookId);

            if (CheckIfBookIsAvailabe(lendedBooks,request.LendDTO.StartDate,request.LendDTO.EndDate))
            {
               
                ComicBook comicBook = await _lendRepository.GetBookByIdAsync(request.LendDTO.BookId);
                Client client = await _lendRepository.GetClientByIdAsync(request.LendDTO.UserId);
                
                Lend lend = new Lend(comicBook, client, request.LendDTO.StartDate, request.LendDTO.EndDate);
                _lendRepository.InsertLendAsync(lend);

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
            if (DateOnly.FromDateTime(start) < DateOnly.FromDateTime(date) &&
                DateOnly.FromDateTime(end) > DateOnly.FromDateTime(date))
                return true;
            else
                return false;
        }

        
    }
}
