using Demo.Drivers;
using Demo.Page;
using Demo.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace Demo.Test
{
    public class BaseTest
    {
        protected static IWebDriver driver;

        public static DropdownDemoPage _dropdownDemoPage;
        public static DemoVTPage _vartuTechnikaPage;
        public static SebCalculatorPage _sebCalculatorPage;

        [OneTimeSetUp]
        public static void OneTimeSetup()
        {
            driver = CustomDriver.GetChromeDriver();
            _dropdownDemoPage = new DropdownDemoPage(driver);
            _vartuTechnikaPage = new DemoVTPage(driver);
            _sebCalculatorPage = new SebCalculatorPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}
