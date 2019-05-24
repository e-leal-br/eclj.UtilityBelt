using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eclj.UtilityBelt.Tests
{
    using eclj.UtilityBelt;

    [TestClass]
    public class Test_DateTimeExtension
    {
        #region Method bool IsWeekend(this DateTime value)
        [TestMethod]
        public void IsWeekend_true()
        {
            var saturday = new DateTime(2019, 5, 25);

            Assert.AreEqual(saturday.IsWeekend(), true);

            var sunday = new DateTime(2019, 5, 26);

            Assert.AreEqual(sunday.IsWeekend(), true);
        }

        [TestMethod]
        public void IsWeekend_false()
        {
            var thursday = new DateTime(2019, 5, 23);

            Assert.AreEqual(thursday.IsWeekend(), false);

            var friday = new DateTime(2019, 5, 24);

            Assert.AreEqual(friday.IsWeekend(), false);
        }
        #endregion
    }
}