using Library.Api.DTOs;
using Library.Api.DTOs.ErrorDTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.LendCommands;
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
using System.Net.Http;
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
        public async Task Get_Address_By_Id_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("api/Client/Address");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<AddressDTO>(result);

            Assert.AreEqual("county1",address.County);
        }

        [Test]
        public async Task Get_Lend_By_Id_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync("api/Lends/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var lend = JsonConvert.DeserializeObject<LendResultDTO>(result);

            Assert.AreEqual(1,lend.LendId);
            Assert.AreEqual("title1", lend.ComicBookTitle);
        }

        [Test]
        public async Task Create_Lend_ShouldReturnInvalidDateResponse()
        {
            var command = new CreateLendCommand
            {
                ComicId = 1,
                UserId = 1,
                StartDate = DateTime.Now.AddDays(20),
                EndDate = DateTime.Now.AddDays(19)
            };
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("api/Lends/BorrowComic/1", new StringContent(JsonConvert.SerializeObject(command),Encoding.UTF8,"application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ErrorDTO>(result);

            Assert.AreEqual("Invalid date", error.ErrorMessage);
        }

        [Test]
        public async Task Create_Lend_ShouldReturnBadRequestResponse()
        {
            var body = new LendDTO
            {
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now
            };
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("api/Lends/BorrowComic/1", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var error = JsonConvert.DeserializeObject<ErrorDTO>(result);

            Assert.AreEqual("Invalid date", error.ErrorMessage);
        }

        [Test]
        public async Task Create_Lend_ShouldReturnCreatedResponse()
        {
            var command = new CreateLendCommand
            {
                ComicId = 1,
                UserId = 1,
                StartDate = DateTime.Now.AddDays(15),
                EndDate = DateTime.Now.AddDays(21)
            };
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("api/Lends/BorrowComic/1", new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var lend = JsonConvert.DeserializeObject<LendResultDTO>(result);

            Assert.AreEqual(1, lend.ClientId);
            Assert.AreEqual("title1", lend.ComicBookTitle);
        }

        [TestCase(1,7)] 
        [TestCase(0,14)]
        [TestCase(1,14)]
        [TestCase(0, 7)]
        [TestCase(-1, 6)]
        [TestCase(2, 8)]
        public async Task Create_Overlapping_Lend_ShouldReturnInvalidEndDateResponse(int start,int end)
        {
            var body = new LendDTO
            {
                StartDate = DateTime.Now.AddDays(start),
                EndDate = DateTime.Now.AddDays(end)
            };
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("api/Lends/BorrowComic/1", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var err = JsonConvert.DeserializeObject<ErrorDTO>(result);

            Assert.AreEqual("this comic book is not available in that time period", err.ErrorMessage);
        }

        [Test]
        public async Task Create_Lend_More_Than_Two_Weeks_ShouldReturnBadRequestResponse()
        {
            var command = new CreateLendCommand
            {
                ComicId = 1,
                UserId = 1,
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(60)
            };
            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync("api/Lends/BorrowComic/1", new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var err = JsonConvert.DeserializeObject<ErrorDTO>(result);

            Assert.AreEqual("lending time cant be more than two weeks", err.ErrorMessage);
        }

        [Test]
        public async Task Extend_Lend_ShouldReturnCreatedResponse()
        {
            DateTime newEndDate = DateTime.Now.AddDays(9);

            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PatchAsync("api/Lends/1", new StringContent(JsonConvert.SerializeObject(new LendExtensionDTO() { NewEndDate = newEndDate}), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var lend = JsonConvert.DeserializeObject<LendResultDTO>(result);

            Assert.AreEqual(newEndDate.Date, lend.EndDate);
            Assert.AreEqual(true, lend.Extended);
        }

        [Test]
        public async Task Extend_Lend_ShouldReturnOkResponse()
        {
            DateTime newEndDate = DateTime.Now.AddDays(9);

            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PatchAsync("api/Lends/1", new StringContent(JsonConvert.SerializeObject(new LendExtensionDTO() { NewEndDate = newEndDate }), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var lend = JsonConvert.DeserializeObject<LendResultDTO>(result);

            Assert.AreEqual(newEndDate.Date, lend.EndDate);
            Assert.AreEqual(true, lend.Extended);
        }

        [TestCase(6)]
        [TestCase(15)]
        [TestCase(7)]
        public async Task Extend_Lend_ShouldReturnBadRequestResponse(int days)
        {
            DateTime newEndDate = DateTime.Now.AddDays(days);

            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PatchAsync("api/Lends/1", new StringContent(JsonConvert.SerializeObject(new LendExtensionDTO() { NewEndDate = newEndDate }), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase(13)]
        [TestCase(12)]
        [TestCase(11)]
        [TestCase(10)]
        public async Task Extend_Overlap_Lend_ShouldReturnBadRequestResponse(int days)
        {
            DateTime newEndDate = DateTime.Now.AddDays(days);

            var client = _factory.CreateClient();
            var user = new Client(1, "user1", new Address("street1", "city1", "county1", 1), "user1@email.com");
            string token = RegistrationService.GenerateJwtToken(user);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PatchAsync("api/Lends/1", new StringContent(JsonConvert.SerializeObject(new LendExtensionDTO() { NewEndDate = newEndDate }), Encoding.UTF8, "application/json"));

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

}
