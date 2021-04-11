using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class RimiDemoTest : BaseTest
    {
        [Test]
        public static void CheckMinimalOrderSum()
        {
            _rimiDemoPage.NavigateToDefaultPage();
            _rimiDemoPage.ClosePopUp();
            _rimiDemoPage.ClickOrder();
            _rimiDemoPage.ClickOrderSum();
            _rimiDemoPage.VerifyMinimalOrderSum();
        }
    }
}
