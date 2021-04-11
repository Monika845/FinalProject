using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class RimiCartWinePage : BasePage
    {
        private const string _pageAddress = "https://www.rimi.lt/e-parduotuve/lt";

        private IWebElement _SearchField => Driver.FindElement(By.Id("search-input"));
        private IWebElement _SearchButton => Driver.FindElement(By.CssSelector(".form-field__wrapper > button > svg"));
        private IWebElement _ToCartWineButton => Driver.FindElement(By.CssSelector(".product-grid__item:nth-child(1) .button"));
        private IWebElement _CartButton => Driver.FindElement(By.CssSelector(".button > span"));
        private IWebElement _visiblePrice => Driver.FindElement(By.CssSelector("#main > section > div > div > aside > div > div.cart__details > dl:nth-child(3) > dd"));
        public RimiCartWinePage(IWebDriver webdriver) : base(webdriver) { }

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

        public void InsertProductWine(string wine)
        {
            _SearchField.SendKeys(wine);
        }

        public void SearchWine()
        {
            _SearchButton.Click();
        }

        public void AddToCartWine()
        {
            _ToCartWineButton.Click();
        }

        public void CheckMyCartAgain()
        {
            _CartButton.Click();
            Assert.IsTrue("7,99 €".Equals(_visiblePrice.Text), "Prices are not the same");
        }


    }
}
