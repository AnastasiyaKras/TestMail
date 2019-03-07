using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.PageObject;
using UnitTest.DataModels;
using NUnit.Framework;
using System.Threading;

namespace UnitTest.TestManager
{
    public class MailManager
    {
        protected IWebDriver driver;
        protected MailPage mailPage;
        protected InboxPage inboxPage;
        protected NewMessagePage newMessagePage;
        public MailManager(IWebDriver driver)
        {
            this.driver = driver;
            mailPage = new MailPage(driver);
            inboxPage = new InboxPage(driver);
            newMessagePage = new NewMessagePage(driver);
        }

        public MailManager Login(MailData data)
        {
            mailPage
                .Open()
                .SwitchIFrameLogin()
                .WaitIFrameLogin()
                .SetUserLogin(data.Login)
                .SetUserPass(data.Password)
                .ClickLoginButton()
                ;
            inboxPage.WaitForRedirect(inboxPage.Url);
            Assert.AreEqual(inboxPage.Url, driver.Url, "Не произошла переадресация");
            return this;
        }
        public MailManager OpenNewLetter()
        {
            inboxPage.ClickWriteButton();
            inboxPage.WaitForRedirect(newMessagePage.Url);
            Assert.AreEqual(newMessagePage.Url, driver.Url, "Не произошла переадресация");
            return this;
        }
        public MailManager WriteLetter(MailData data)
        {
            newMessagePage
                .SetAddress(data.Address)
                .SetTheme(data.Theme)
                .SwitchToIFrameEditor()
                .SetContent(data.Content)
                ;
            return this;
        }
        public MailManager SaveLetter()
        {
            newMessagePage
                .SwitchFromFrame()
                .ClickSaveButton()
                .WaitNotification()
                ;
            Assert.IsTrue(newMessagePage.NotificationDisplay, "Черновик не сохранен");
            return this;
        }
        public MailManager SendLetter()
        {
            newMessagePage
                .SwitchFromFrame()
                .ClickSendButton()
                .WaitSentNotification()
                ;
            Assert.IsTrue(newMessagePage.SentNotificationDisplay, "Письмо не отправлено");
            return this;
        }
        public MailManager OpenMailBox(MailData data, string action)
        {
            if (action == "Save")
            {
                inboxPage.ClickDraftBoxButton();
            }
            if (action == "Send")
            {
                inboxPage.ClickSentBoxButton();
            }
            inboxPage
                .ClickDraftBoxLastLetter()
                .WaidOpenLetter()
                ;
            Assert.AreEqual(data.Theme, inboxPage.HeaderLetterText, "Тема письма не соответствует ожидаемому результату");
            Assert.AreEqual(data.Address, inboxPage.AdressLetterText, "Адрес письма не соответствует ожидаемому результату");
            Assert.AreEqual(data.Content, inboxPage.ContentLetterText, "Тело письма не соответствует ожидаемому результату");
            return this;
        }
        public MailManager ExitMail()
        {
            inboxPage
                .ClickTopLineUser()
                .ClickExitButton()
                .WaitForRedirect("https://www.rambler.ru/");
            ;
            Assert.AreEqual("https://www.rambler.ru/", driver.Url, "Не произошла переадресация");
            // дляhttps://www.rambler.ru/ создать переменную  
            return this;
        }
    }
}
