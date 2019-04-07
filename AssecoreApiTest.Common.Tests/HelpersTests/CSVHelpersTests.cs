using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;
using System.IO;
using AssecoreApiTest.Business.Dto;
using System.Linq;

namespace Common.Tests.HelpersTests
{
    [TestClass]
    public class CSVHelpersTests
    {
        [TestMethod]
        public void ReadFileTest()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDir, "TestFiles", "CsvData.csv");

            var csvTestDataTextReader = new StreamReader(filePath, System.Text.Encoding.UTF8);

            var users = CsvHelpers.ReadFileWithoutHeader<UserDto>(csvTestDataTextReader, typeof(UserCsvMap));

            Assert.IsTrue(users?.Count() > 0);
        }
    }
}
