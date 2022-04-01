﻿using Library.Application.Commands.BookCommands;
using Library.Application.Commands.BookCommands.CreateBookCommand;
using Library.Application.DTOs;
using Library.Application.utils;
using Library.Core;
using Library.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers.BookHandlers
{
    internal class CreateComicBookCommandHandler : IRequestHandler<CreateComicBookCommand, ComicBookDetailDTO>
    {
        IBookRepository _bookRepository;

        public CreateComicBookCommandHandler()
        {
            _bookRepository = new ComicBookRepository();
        }

        public Task<ComicBookDetailDTO> Handle(CreateComicBookCommand request, CancellationToken cancellationToken)
        {
            var book = new ComicBook(request.BookDTO.Title,request.BookDTO.Author,GenreConverter.FromString(request.BookDTO.Genre));
            _bookRepository.InsertBook(book);
            return Task.FromResult(request.BookDTO);
        }
    }
}