/* Automatinio testavimo pirmos paskaitos skaidres, 
23 sk, 2021-03-23 */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Class1
    {

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("2", "2", "4", TestName ="2 plius 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]

        public static void TestSum(string firstName, string secondName, string result)
        {
            IWebElement firstInput = _driver.FindElement(By.Id("sum1"));
            IWebElement secondInput = _driver.FindElement(By.Id("sum2"));
            firstInput.Clear();
            firstInput.SendKeys(firstName);
            secondInput.Clear();
            secondInput.SendKeys(secondName);
            _driver.FindElement(By.CssSelector("#gettotal > button")).Click();
            IWebElement resultFromPage = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, resultFromPage.Text, "Result is NOK");
        }

        /*[Test]

        public static void TestSeleniumPage2()
        {
            IWebElement InputField1 = driver.FindElement(By.Id("sum1"));
            int skaicius1 = -5;
            InputField1.SendKeys(Convert.ToString(skaicius1));
            IWebElement InputField2 = driver.FindElement(By.Id("sum2"));
            int skaicius2 = 3;
            InputField2.SendKeys(Convert.ToString(skaicius2));
            int sum = skaicius1 + skaicius2;
            IWebElement button = driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sum.ToString(), result.Text, "Result is NOK");
        }

        [Test]

        public static void TestSeleniumPage3()
        {
            IWebElement InputField1 = driver.FindElement(By.Id("sum1"));
            string raide1 = "a";
            InputField1.SendKeys(raide1);
            IWebElement InputField2 = driver.FindElement(By.Id("sum2"));
            string raide2 = "b";
            InputField2.SendKeys(raide2);
            string sum = raide1 + raide2;
            IWebElement button = driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sum.ToString(), result.Text, "Result is NOK");
        }*/
    }
}
