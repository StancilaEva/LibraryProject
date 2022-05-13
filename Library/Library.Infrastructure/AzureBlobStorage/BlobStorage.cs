using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.AzureBlobStorage
{
    public class BlobStorage : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;


        public Task UploadFileBlobAsync(string filePath,string fileName)
        {
            return null;
        }
    }
}
