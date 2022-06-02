using Library.Api.DTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.JwtTokenGeneration;
using Library.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnitLibraryTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    internal class IntegrationLendTests
    {
        private static WebApplicationFactory<Program> _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Test]
        public async Task Get_Lend_By_Id_ShouldReturnUnauthorizedResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/Lends/1");

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Test]
        public async Task Get_Lend_By_Id_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var user = new Client("identityId1", "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                RegistrationService.GenerateJwtToken(user));
            var response = await client.GetAsync("api/Lends/1");

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var lend = JsonConvert.DeserializeObject<LendResultDTO>(result);

            Assert.AreEqual(user.Id, lend.ClientId);
        }

    }
}
