using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace UnitTest.PageObject
{
    public class PageObjectBase<T> where T : PageObjectBase<T>
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

    public virtual string ShortUrl
        {
            get
            {
                return "";
            }
        }
    public string Url
        {
            get
            {
                return ShortUrl.Contains("http") || ShortUrl.Contains("www")
                    ?ShortUrl
                    : ConfigurationManager.AppSettings.Get("BaseUrl") + ShortUrl;
            }
        }
    public T Open()
        {
            // открываем страницу почты
            driver.Navigate().GoToUrl(Url);
            return (T)this;
        }
    public PageObjectBase(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2000));
        }
    }
}
