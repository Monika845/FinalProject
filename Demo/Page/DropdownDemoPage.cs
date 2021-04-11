﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace Demo.Page
{
    public class DropdownDemoPage : BasePage
    {
        private const string _pageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        private const string _defaultText = "Day selected :- ";

        private const string _firstSelectedPrefixText = "First selected option is : ";
        private SelectElement _firstDropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _visibleText => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _getAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _multiResultText => Driver.FindElement(By.CssSelector(".getall-selected"));

        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAddress;
        }
        public void NavigateToDefaultPage()
        {
            if (Driver.Url != _pageAddress)
                Driver.Url = _pageAddress;
        }

        public void SelectFromDropdownByValue(DayOfWeek value)
        {
            _firstDropDown.SelectByValue(value.ToString());
        }

        public void SelectFromDropdownByText(string visibleText)
        {
            _firstDropDown.SelectByText(visibleText);
        }

        public void SelectFromDropdownByText(int index)
        {
            _firstDropDown.SelectByIndex(index);
        }

        public void VerifySelectedValue(DayOfWeek value)
        {
            //Assert.IsTrue(_visibleText.Text.Contains(value));
            Assert.AreEqual(_defaultText + value.ToString(), _visibleText.Text, "Texts are not equal");
        }

        public void SelectFromMultipleDropdown(List<string> statesList)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (string state in statesList)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")) && !option.Selected)
                    {
                        option.Click();
                    }
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }

        public void ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
        }

        public void ClickGetAllSelectedButton()
        {
            _getAllSelectedButton.Click();
        }
        public void VerifyFirstSelectedState(string firstState)
        {
            Assert.AreEqual(_firstSelectedPrefixText + firstState, _multiResultText.Text, "Text is wrong");
        }

        public void VerifyAllSelectedState(string firstState)
        {
            Assert.AreEqual(_firstSelectedPrefixText + firstState, _multiResultText.Text, "Text is wrong");
        }

    }
}
