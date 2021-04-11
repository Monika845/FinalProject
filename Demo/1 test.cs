/* Automatinio testavimo pirmos paskaitos skaidres, 
14 ir 15 sk, 2021-03-22 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool
{
    public class Class1
    {
      [Test] 

      public static void Test4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

      [Test]

      public static void TestNowIs18()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.AreEqual(19, CurrentTime.Hour, "Dabar ne 18h");
        }

      [Test]

        public static void Test995DalijasiIs3()
        {
            int leftover = 995 % 3;
            Assert.AreEqual(0, leftover, "995 nesidalija be liekanos");
        }

      [Test]

        public static void TestIfTodayIsMonday()
        {
            DateTime CurrentTime = DateTime.Today;
            Assert.AreEqual(DayOfWeek.Monday, CurrentTime.DayOfWeek, "Today is not Monday");
        }


        [Test]
        public static void TestWaitfor5sec()
        {
            Thread.Sleep(5000);
        }

    }
}
