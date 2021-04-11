using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    public class RimiCareerTest : BaseTest
    {
        [Test]
        public static void CheckJobPosition()
        {
            _rimiCareerPage.NavigateToDefaultPage();
            _rimiCareerPage.ClosePopUp();
            _rimiCareerPage.CheckVacanciesList();
            _rimiCareerPage.CheckMarketingTeamLeadJob();
            _rimiCareerPage.CheckSimilarExperienceWork();
        }
    }
}
