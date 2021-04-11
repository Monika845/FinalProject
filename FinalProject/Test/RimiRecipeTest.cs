using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class RimiRecipeTest : BaseTest
    {
        [Test]
        public static void CheckRecipeProductsInCart()
        {
            _rimiRecipePage.NavigateToDefaultPage();
            _rimiRecipePage.ClosePopUp();
            _rimiRecipePage.InsertRecipe("panakota");
            _rimiRecipePage.SearchRecipe();
            _rimiRecipePage.ChoosePanacotaRecipe();
            _rimiRecipePage.SelectPortion("4");
            _rimiRecipePage.AddToCart();
            _rimiRecipePage.CheckCart();
        }
    }
}
