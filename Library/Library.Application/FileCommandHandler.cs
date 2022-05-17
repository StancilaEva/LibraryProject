using Library.Infrastructure.AzureBlobStorage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class FileCommandHandler : IRequestHandler<FileCommand, string>
    {
        IBlobService _blobService;

        public FileCommandHandler( IBlobService blobService)
        {
            _blobService = blobService;
        }

        public async Task<string> Handle(FileCommand request, CancellationToken cancellationToken)
        {
            string coverUrl = await _blobService.UploadFileBlobAsync(request.File);
            return coverUrl;
        }
    }
}
