using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class RimiCartTest : BaseTest
    {
        [Test]
        public static void IWantToBuyCakeRedVelvet()
        {
            _rimiCartPage.NavigateToDefaultPage();
            _rimiCartPage.ClosePopUp();
            _rimiCartPage.InsertProductRaffaello("raffaello, 230g");
            _rimiCartPage.SearchRaffaello();
            _rimiCartPage.AddToCartRaffaello();
            _rimiCartPage.CheckMyCart();
        }

    }
}
