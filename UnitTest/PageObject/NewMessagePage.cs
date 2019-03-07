using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;

namespace UnitTest.PageObject
{
    public class NewMessagePage : PageObjectBase<MailPage>
    {
        public NewMessagePage(IWebDriver driver) : base(driver)
        {
        }
        public override string ShortUrl
        {
            get
            {
                return "#/compose";
            }
        }

        #region page elements
        private IWebElement Receivers
        {
            get
            {
                return driver.FindElement(By.Id("receivers"));
            }
        }
        private IWebElement Subject
        {
            get
            {
                return driver.FindElement(By.CssSelector("#subject"));
            }
        }
        private IWebElement IFrameEditor
        {
            get
            {
                return driver.FindElement(By.Id("editor_ifr"));
            }
        }
        private IWebElement Editor
        {
            get
            {
                return driver.FindElement(By.CssSelector("#tinymce"));
            }
        }
        private IWebElement SaveButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("#compose > div > div.Compose-send-O- > div > div > div.Compose-saveToDrafts-3_ > div:nth-child(1)"));
            }
        }
        private IWebElement Notification
        {
            get
            {
                return driver.FindElement(By.ClassName("notification-visible"));
            }
        }
        private IWebElement SendButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("div.Compose-content-2V > button"));
            }
        }
        private IWebElement SentNotification
        {
            get
            {
                return driver.FindElement(By.CssSelector("header.SentLetter-head-1P"));
            }
        }
        #endregion

        #region page actions
        public NewMessagePage SetAddress(string Address)
        {
            Receivers.SendKeys(Address);
            return this;
        }
        public NewMessagePage SetTheme(string Theme)
        {
            Subject.SendKeys(Theme);
            return this;
        }
        public NewMessagePage SwitchToIFrameEditor()
        {
            driver.SwitchTo().Frame(IFrameEditor);
            return this;
        }
        public NewMessagePage SetContent(string Content)
        {
            Editor.SendKeys(Content);
            return this;
        }
        public NewMessagePage SwitchFromFrame()
        {
            driver.SwitchTo().DefaultContent();
            return this;
        }
        public NewMessagePage ClickSaveButton()
        {
            SaveButton.Click();
            return this;
        }
        public NewMessagePage WaitNotification()
        {
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("notification-visible")));
            return this;
        }
        public NewMessagePage ClickSendButton()
        {
            SendButton.Click();
            return this;
        }
        public NewMessagePage WaitSentNotification()
        {
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("header.SentLetter-head-1P")));
            return this;
        }
        #endregion

        public bool NotificationDisplay
        {
            get
            {
                return Notification.Displayed;
            }
        }
        public bool SentNotificationDisplay
        {
            get
            {
                return SentNotification.Displayed;
            }
        }

    }
}
