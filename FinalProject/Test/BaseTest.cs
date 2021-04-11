using FinalProject.Drivers;
using FinalProject.Page;
using FinalProject.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static RimiDemoPage _rimiDemoPage;
        public static RimiCartPage _rimiCartPage;
        public static RimiCareerPage _rimiCareerPage;
        public static RimiCartWinePage _rimiCartWinePage;
        public static RimiRecipePage _rimiRecipePage;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _rimiDemoPage = new RimiDemoPage(driver);
            _rimiCartPage = new RimiCartPage(driver);
            _rimiCareerPage = new RimiCareerPage(driver);
            _rimiCartWinePage = new RimiCartWinePage(driver);
            _rimiRecipePage = new RimiRecipePage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
