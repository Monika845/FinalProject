using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Page;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Page
{
    public class RimiCartPage : BasePage
    {
        private const string _pageAddress = "https://www.rimi.lt/e-parduotuve/lt";

        private IWebElement _SearchField => Driver.FindElement(By.Id("search-input"));
        private IWebElement _SearchButton => Driver.FindElement(By.CssSelector(".form-field__wrapper > button > svg"));
        private IWebElement _ToCartRaffaelloButton => Driver.FindElement(By.CssSelector(".product-grid__item:nth-child(1) .button"));
        private IWebElement _CartButton => Driver.FindElement(By.CssSelector(".button > span"));
        private IWebElement _visiblePrice => Driver.FindElement(By.CssSelector("#main > section > div > div > aside > div > div.cart__details > dl:nth-child(3) > dd"));
        public RimiCartPage(IWebDriver webdriver) : base(webdriver) { }

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

        public void InsertProductRaffaello(string sweets)
        {
            _SearchField.SendKeys(sweets);
        }

        public void SearchRaffaello()
        {
            _SearchButton.Click();
        }

        public void AddToCartRaffaello()
        {
            _ToCartRaffaelloButton.Click();
        }

        public void CheckMyCart()
        {
            _CartButton.Click();
            Assert.IsTrue("3,95 €".Equals(_visiblePrice.Text), "Prices are not the same");
        }
    }
}
