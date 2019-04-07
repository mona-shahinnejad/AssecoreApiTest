using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web.Http.Results;
using AssecoreApiTest.Business.Dto;
using AssecoreApiTest.Business.IService;
using AssecoreApiTest.Business.Service;
using AssecoreApiTest.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssecoreApiTest.WebApi.Tests.UserControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        private const string serverAddress = "http://localhost:55050/";
        private const string baseUserApiAddress = "api/person";

        private const string getPersonsAddress = "/persons";

        [TestMethod]
        public void GetPersonsTest()
        {
            var getUrl = Path.Combine(serverAddress + baseUserApiAddress + getPersonsAddress);
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(getUrl);

            response.Result.EnsureSuccessStatusCode();

            string content = response.Result.Content.ReadAsStringAsync().Result;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(content) && content.Contains("FirstName"));
        }
    }
}
