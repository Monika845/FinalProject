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
    public class RimiCareerPage : BasePage
    {
        private const string _pageAddress = "https://www.rimi.lt/karjera";

        private const string _defaultText = "At least 3 years of experience working in a similar role.";
        private IWebElement _reviewVacanciesButton => Driver.FindElement(By.CssSelector("body > main > div > div > div > ul > li:nth-child(2) > a"));
        private IWebElement _marketingTeamLeadButton => Driver.FindElement(By.CssSelector(".vacancies__grid__item:nth-child(3) > .vacancies__grid__col:nth-child(1) > a"));
        private IWebElement _similarExperienceWorkText => Driver.FindElement(By.CssSelector("ul:nth-child(5) > li:nth-child(1)"));
        public RimiCareerPage(IWebDriver webdriver) : base(webdriver) { }

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

        public void CheckVacanciesList()
        {
            _reviewVacanciesButton.Click();
        }

        public void CheckMarketingTeamLeadJob()
        {
            _marketingTeamLeadButton.Click();
        }

        public void CheckSimilarExperienceWork()
        {
            Assert.IsTrue(_defaultText.Equals(_similarExperienceWorkText), "Text is wrong");
        }

    }
}
