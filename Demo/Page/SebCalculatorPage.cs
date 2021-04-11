using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace Demo.Page
{
    public class SebCalculatorPage : BasePage
    {
        private const string PageAddress = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";
        private IWebElement _incomeInput => Driver.FindElement(By.Id("income"));

        private SelectElement _cityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));

        private IWebElement _calculateButton => Driver.FindElement(By.Id("calculate"));

        private IWebElement _resultTextElement => Driver.FindElement(By.CssSelector(".ng-binding:nth-child(1) > .ng-binding"));

        public SebCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public SebCalculatorPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SebCalculatorPage ClosePop()
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".main.accept-selected")));
            Driver.FindElement(By.CssSelector(".main.accept-selected")).Click();
            return this;
        }

        public SebCalculatorPage InsertIncome(string income)
        {
            _incomeInput.Clear();
            _incomeInput.SendKeys(income);
            return this;
        }

        public SebCalculatorPage SelectFromCityDropdownByValue(string value)
        {
            _cityDropdown.SelectByValue(value);
            return this;
        }


        public SebCalculatorPage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

        public SebCalculatorPage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }

        public SebCalculatorPage CheckIfICanGetLoan(int wantedLoan)
        {
            string possibleLoanValue = _resultTextElement.Text.Trim().Replace(" ", "");
            Assert.IsTrue(wantedLoan < GetParsedValue(possibleLoanValue), "Nope, no loan for me");
            return this;
        }

        private int GetParsedValue(string value)
        {
            int parsedValue = 0;
            if (!"".Equals(value) && value != null)
            {
                parsedValue = Int32.Parse(value);
            }
            return parsedValue;
        }
    }
}
