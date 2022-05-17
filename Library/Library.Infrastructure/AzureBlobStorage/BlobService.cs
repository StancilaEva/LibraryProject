using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.AzureBlobStorage
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string>  UploadFileBlobAsync(IFormFile file)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("covers");
            var blobClient = containerClient.GetBlobClient(file.FileName);

            using var stream =  file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
