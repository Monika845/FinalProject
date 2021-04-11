﻿using Demo.Test;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsWebdriver.Page;

namespace VcsWebdriver.Test
{
    public class DemoVTTest : BaseTest
    {

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665,98€")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000 x 2000 + Vartų automatika + Vartų montavimo darbai = 1006,43€")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000 x 2000 = 692,35€")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000 x 2000 + Vartų montavimo darbai = 989,21€")]
        public static void TestVartuTechnika(string width, string height, bool auto, bool works, string result)
        {
            _vartuTechnikaPage.NavigateToHomePage();
            _vartuTechnikaPage.InsertWidthAndHeight(width, height);
            _vartuTechnikaPage.CheckAutoCheckbox(auto);
            _vartuTechnikaPage.CheckWorksCheckbox(works);
            _vartuTechnikaPage.ClickCalculateButton();
            _vartuTechnikaPage.CheckResult(result);
        }
    }
}
