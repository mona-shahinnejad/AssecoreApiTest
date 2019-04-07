using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Helpers;

namespace Common.Tests.HelpersTests
{
    [TestClass]
    public class ConfigurationHelpersTests
    {
        [TestMethod]
        public void ReadAppConfig()
        {
            var data = ConfigurationReader.ReadAppConfig("TestKey", "DefaultValue");

            Assert.AreEqual("TestValue", data);
        }

        [TestMethod]
        public void ReadAppConfigByDefaultValue()
        {
            var data = ConfigurationReader.ReadAppConfig("NotExistKey", "DefaultValue");

            Assert.AreEqual("DefaultValue", data);
        }
    }
}
