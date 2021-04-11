using Demo.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class DropdownDemoTest : BaseTest
    {

        [Test]
        public void TestDropdown()
        {
            _dropdownDemoPage.NavigateToDefaultPage();
        }
        
        [TestCase("Florida", TestName = "First selected Ohio")]
        [TestCase("California", TestName = "First selected California")]
        //public static void MultipleDropdownFirstSelectedTest(params string[] states)

        public static void MultipleDropdownFirstSelectedTest(string states)
        {
            List<string> state = states.Split(',').ToList();
            _dropdownDemoPage.SelectFromMultipleDropdown(state);
            _dropdownDemoPage.ClickFirstSelectedButton();
            _dropdownDemoPage.VerifyFirstSelectedState(state[0]);
        }

        public static void MultipleDropdownAllSelectedTest()
        {
            List<string> elements = new List<string> { "Ohio", "Florida", "California" };
            _dropdownDemoPage.SelectFromMultipleDropdown(elements);
            _dropdownDemoPage.ClickGetAllSelectedButton();
            _dropdownDemoPage.VerifyFirstSelectedState(elements[0]);
        }
    }
}
