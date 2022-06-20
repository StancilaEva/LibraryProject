using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Library.Api.DTOs;

namespace NUnitLibraryTests
{
    public class IntegrationComicBookTests
    {
        private static WebApplicationFactory<Program> _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Test]
        public async Task Get_Comic_By_Id_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/ComicBooks/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<ComicBookDTO>(result);

            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("title1", book.Title);
            Assert.AreEqual("publisher1", book.Publisher);
        }

        [Test]
        public async Task Get_Comic_By_Id_ShouldReturnNotFoundResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/ComicBooks/8");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
