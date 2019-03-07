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
    public class InboxPage : PageObjectBase<MailPage>
    {
        public InboxPage(IWebDriver driver) : base(driver)
        {
        }
        public override string ShortUrl
        {
            get
            {
                return "#/folder/INBOX";
            }
        }

        #region page elements
        private IWebElement WriteButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("div.Header-button-3g"));
            }
        }
        private IWebElement DraftBoxButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("ul._Menu-root-7A > li:nth-child(3) > div"));
            }
        }
        private IWebElement DraftBoxLastLetter
        {
            get
            {
                return driver.FindElement(By.CssSelector("div.AppContainer-mainContainer-3e.AutoAppContainer-mainContainer-P4 > div > div:nth-child(3) > div > div:nth-child(2) > div:nth-child(1) > div"));
            }
        }
        private IWebElement HeaderLetter
        {
            get
            {
                return driver.FindElement(By.CssSelector("h2.LetterHeader-subject-3U"));
            }
        }
        private IWebElement AdressLetter
        {
            get
            {
                return driver.FindElement(By.CssSelector("span.LetterHeader-toNames-32 > span > span > span > span.ContactWithDropdown-headerEmailWrapper-x0 > span"));
            }
        }
        private IWebElement ContentLetter
        {
            get
            {
                return driver.FindElement(By.CssSelector("#part2 > div.messageBody.isFormattedText > div > div"));
            }
        }
        private IWebElement TopLineUser
        {
            get
            {
                return driver.FindElement(By.CssSelector("span.rui-ToplineUser-username"));
            }
        }
        private IWebElement ExitButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("button.rui-ToplineUser-logout"));
            }
        }
        private IWebElement SentBoxButton
        {
            get
            {
                return driver.FindElement(By.CssSelector("ul._Menu-root-7A > li:nth-child(2) > div"));
            }
        }
        #endregion

        #region page actions
        //этот метод нужно вынести в какое-нибудь базовое место..
        public InboxPage WaitForRedirect(string newUrl)
        {
            wait.Until(d => driver.Url == newUrl);
            return this;
        }
        public InboxPage ClickWriteButton()
        {
            WriteButton.Click();
            return this;
        }
        public InboxPage ClickDraftBoxButton()
        {
            DraftBoxButton.Click();
            return this;
        }
        public InboxPage ClickDraftBoxLastLetter()
        {
            DraftBoxLastLetter.Click();
            return this;
        }
        public InboxPage ClickTopLineUser()
        {
            TopLineUser.Click();
            return this;
        }
        public InboxPage ClickExitButton()
        {
            ExitButton.Click();
            return this;
        }
        public InboxPage WaidOpenLetter()
        {
            wait.Until(d => HeaderLetter);
            return this;
        }
        public InboxPage ClickSentBoxButton()
        {
            SentBoxButton.Click();
            return this;
        }
        
        #endregion

        public string HeaderLetterText
        {
            get
            {
                return HeaderLetter.Text;
            }
        }
        public string AdressLetterText
        {
            get
            {
                return AdressLetter.Text;
            }
        }
        public string ContentLetterText
        {
            get
            {
                return ContentLetter.Text;
            }
        }
    }
}
