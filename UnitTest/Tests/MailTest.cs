using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.DataModels;
using UnitTest.TestManager;
using UnitTest.PageObject;

namespace UnitTest.Tests
{
    [TestFixture]
    public class MailTest : TestBase
    {
        public static IEnumerable<MailData> SaveMailFromXML()
        {
            return ModelDataFromXmlFile<MailData>("SaveMail.xml");
        }
    [Test, TestCaseSource(nameof(SaveMailFromXML))]
    public void SaveMailTest(MailData data)
        {
            MailManager mm = new MailManager(driver);
            mm
                .Login(data)
                .OpenNewLetter()
                .WriteLetter(data)
                .SaveLetter()
                .OpenMailBox(data, "Save")
                .ExitMail()
                ;
        }
    [Test, TestCaseSource(nameof(SaveMailFromXML))]
     public void SendMailTest(MailData data)
        {
            MailManager mm = new MailManager(driver);
            mm
                .Login(data)
                .OpenNewLetter()
                .WriteLetter(data)
                .SendLetter()
                .OpenMailBox(data, "Send")
                .ExitMail()
                ;
        }
    }
}
