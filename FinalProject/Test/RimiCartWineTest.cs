using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class RimiCartWineTest : BaseTest
    {
        [Test]
        public static void AndNonAlcoholicWine()
        {
            _rimiCartWinePage.NavigateToDefaultPage();
            _rimiCartWinePage.ClosePopUp();
            _rimiCartWinePage.InsertProductWine("gancia prosecco");
            _rimiCartWinePage.SearchWine();
            _rimiCartWinePage.AddToCartWine();
            _rimiCartWinePage.CheckMyCartAgain();
        }
    }
}
