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
    public class MailPage : PageObjectBase<MailPage>
    {
        public MailPage(IWebDriver driver) : base(driver)
        {
        }
        public override string ShortUrl
        {
            get
            {
                return "";
            }
        }

        #region page elements
        private IWebElement IFrameLogin
        {
            get
            {
                return driver.FindElement(By.CssSelector("div.c0211 > iframe"));
            }
        }
        private IWebElement UserLogin
        {
            get
            {
                return driver.FindElement(By.Id("login"));
            }
        }
        private IWebElement UserPass
        {
            get
            {
                return driver.FindElement(By.Id("password"));
            }
        }
        private IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.ClassName("rui-Button-block"));
            }
        } 
        #endregion

        #region page actions
        public MailPage WaitIFrameLogin()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("login")));
            return this;
        }
        public MailPage SwitchIFrameLogin()
        {
            driver.SwitchTo().Frame(IFrameLogin);
            return this;
        }
        public MailPage SetUserLogin(string Login)
        {
            UserLogin.SendKeys(Login);
            return this;
        }
        public MailPage SetUserPass(string Password)
        {
            UserPass.SendKeys(Password);
            return this;
        }
        public MailPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }
        #endregion

    }
}
