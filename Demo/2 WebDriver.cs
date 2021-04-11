/* Automatinio testavimo pirmos paskaitos skaidres,
2021-03-22 */
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Demo
{
    public class WebDriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");
            //chrome.Close();
        }

        [Test]

        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement InputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Labas";
            InputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
            //chrome.Quit();
        }
    }

}
