using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class _6_namu_darbas_04_01
    {
        private static IWebDriver _driver;

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void TestBrowserChrome()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            IWebElement text = _driver.FindElement(By.Id("primary-detection"));
            Assert.IsTrue("Chrome 89 on Windows 1".Equals(text.Text));
        }

        [Test]
        public static void TestBrowserFirefox()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            IWebElement text = _driver.FindElement(By.Id("primary-detection"));
            Assert.IsTrue("Firefox 87 on Windows 10".Equals(text.Text));
        }
    }
}
