using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject.Page
{
    public class RimiRecipePage : BasePage
    {
        private const string _pageAddress = "https://www.rimi.lt/receptai";

        private IWebElement _SearchField => Driver.FindElement(By.CssSelector(".recipes-search:nth-child(1) .form-field__input"));
        private IWebElement _SearchButton => Driver.FindElement(By.CssSelector(".recipes-search:nth-child(1) .icon"));
        private IWebElement _PanacotaButton => Driver.FindElement(By.CssSelector(".recipes-item:nth-child(2) .background__link"));
        private SelectElement _PortionDropDown => new SelectElement(Driver.FindElement(By.CssSelector(".js-portions-input")));
        private IWebElement _ToCartButton => Driver.FindElement(By.CssSelector("form:nth-child(3) > .button"));
        private IWebElement _CartButtonPopUp => Driver.FindElement(By.CssSelector(".recipes-modal__action-wrapper > .button"));
        private IWebElement _CartButton => Driver.FindElement(By.CssSelector(".button > span"));
        public RimiRecipePage(IWebDriver webdriver) : base(webdriver) { }

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

        public void InsertRecipe(string recipe)
        {
            _SearchField.SendKeys(recipe);
        }

        public void SearchRecipe()
        {
            _SearchButton.Click();
        }

        public void ChoosePanacotaRecipe()
        {
            _PanacotaButton.Click();
        }

        public void SelectPortion(string value)
        {
            _PortionDropDown.SelectByValue(value.ToString());
        }
        
        public void AddToCart()
        {
            _ToCartButton.Click();
            _CartButtonPopUp.Click();
            Thread.Sleep(10000);
        }

        public void CheckCart()
        {
            _CartButton.Click();
        }
    }
}
