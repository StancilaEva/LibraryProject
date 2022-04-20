
using Library.Application.Queries;
using Library.Core;
using Library.Core.Interfaces.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Handlers
{
    public class GetAllComicBooksQueryHandler : IRequestHandler<GetAllComicBooksQuery, List<ComicBook>>
    {
        private IBookRepository _bookRepository;

        public GetAllComicBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ComicBook>> Handle(GetAllComicBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetAllBooksAsync();

            result = convertCoverImages(result);
            return result;
        }

        private List<ComicBook> convertCoverImages(List<ComicBook> result)
        {
            foreach (var item in result)
            {
                byte[] bytes = File.ReadAllBytes(item.Cover);
                string encodedCover = Convert.ToBase64String(bytes);
                item.Cover = encodedCover;
            }
            return result;
        }
    }  
}
