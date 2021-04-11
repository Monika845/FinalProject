using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Page;

namespace FinalProject.Page
{
    public class RimiDemoPage : BasePage
    {
        private const string _pageAddress = "https://www.rimi.lt/e-parduotuve/lt/duk";

        private const string _defaultText = "Minimali užsakymo suma yra 20,00 Eur.";
        private IWebElement _orderClickButton => Driver.FindElement(By.CssSelector(".help-section__category-item:nth-child(6) > span"));
        private IWebElement _minimalOrderSumClickButton => Driver.FindElement(By.CssSelector(".accordion__item:nth-child(2) > header > span"));
        private IWebElement _minimalOrderSumText => Driver.FindElement(By.XPath("//div[2]/section/div/p/span/span"));


        public RimiDemoPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
                Driver.Url = _pageAddress;
        }

        public void ClosePopUp()
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.Id("CybotCookiebotDialogBodyButtonAccept")));
            Driver.FindElement(By.Id("CybotCookiebotDialogBodyButtonAccept")).Click();
        }

        public void ClickOrder()
        {
            _orderClickButton.Click();
        }

        public void ClickOrderSum()
        {
            _minimalOrderSumClickButton.Click();
        }

        public void VerifyMinimalOrderSum()
        {
            Assert.IsTrue(_defaultText.Equals(_minimalOrderSumText.Text), "Text is wrong");
        }

    }
}
