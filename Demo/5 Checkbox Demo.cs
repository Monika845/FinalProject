using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class _5_Checkbox_Demo
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public static void OneCheckbox()
        {
            _driver.FindElement(By.Id("isAgeSelected")).Click();
            IWebElement text = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue("Success - Check box is checked".Equals(text.Text));
        }

        [Test]
        public static void MultipleCheckbox()
        {
            IReadOnlyCollection<IWebElement> multipleCheckboxList = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in multipleCheckboxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
            IWebElement resultButton = _driver.FindElement(By.Id("check1"));
            Assert.AreEqual("Uncheck All", resultButton.GetAttribute("value"), "Value is not correct");
        }

        [Test]
        public static void UncheckAllCheckbox()
        {
            IReadOnlyCollection<IWebElement> multipleCheckboxList = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in multipleCheckboxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
            IWebElement resultButton = _driver.FindElement(By.Id("check1"));
            _driver.FindElement(By.Id("check1")).Click();
            Assert.AreEqual("Check All", resultButton.GetAttribute("value"), "Value is not correct");

        }
    }
}
