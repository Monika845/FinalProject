using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class SebCalculatorTest : BaseTest
    {
        [Test]
        public static void CalculateLoan()
        {
            _sebCalculatorPage.NavigateToDefaultPage();
            _sebCalculatorPage.ClosePop();
            _sebCalculatorPage.SwitchToFrame();
            _sebCalculatorPage.InsertIncome("1000");
            _sebCalculatorPage.SelectFromCityDropdownByValue("Klaipeda");
            _sebCalculatorPage.ClickCalculateButton();
            _sebCalculatorPage.CheckIfICanGetLoan(75000);
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname visus pasirinkimus")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname visus pasirinkimus")]
        public void TestMultipleDropdownGetAll(params string[] selectedElements)
        {
            _dropdownDemoPage.NavigateToDefaultPage();
        }
    }
}
