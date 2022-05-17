using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.AzureBlobStorage
{
    public interface IBlobService
    {
        public Task<string> UploadFileBlobAsync(IFormFile file);
    }
}
