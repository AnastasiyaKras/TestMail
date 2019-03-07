using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.DataModels;
using System.Xml.Serialization;
using OpenQA.Selenium.Chrome;

namespace UnitTest.Tests
{
    [TestFixture]
    public class TestBase
    {
        protected const string testDataPath = @"\TestData\";
        protected IWebDriver driver;

        protected static IEnumerable<T> ModelDataFromXmlFile<T>(string filename) where T : MailData
        {
            var TestDirectory = TestContext.CurrentContext.TestDirectory;
            var loaderList = (List<T>)
                new XmlSerializer(typeof(List<T>)).Deserialize(new StreamReader(TestDirectory + testDataPath + filename));
            // тут должна быть обработка исключений
            return loaderList;
        }
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
