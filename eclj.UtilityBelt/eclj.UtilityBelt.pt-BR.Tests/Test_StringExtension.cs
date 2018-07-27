using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace eclj.UtilityBelt.pt_BR.Tests
{
    [TestClass]
    public class Test_StringExtension
    {
        #region Method KeyvaluePair<bool, string> isCPF(this string value)
        [TestMethod]
        public void isCPF_success()
        {
            var value = "655.237.870-00";

            var result = value.isCPF();

            Assert.IsTrue(result.Key, $"{value} should return true (returning message: '{result.Value}').");
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void isCPF_error_nullOrEmpty(string value)
        {
            var result = value.isCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
        }

        [DataTestMethod]
        [DataRow("655.")]
        [DataRow("655.237.870-0000000")]
        public void isCPF_error_notElevenCharacters(string value)
        {
            var result = value.isCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
        }

        [TestMethod]
        public void isCPF_error_firstDigit()
        {
            //  Correct
            //value = "655.237.870-00";
            //  Wrong
            var value = "655.237.870-90";

            var result = value.isCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
        }

        [TestMethod]
        public void isCPF_error_secondDigit()
        {
            //  Correct
            //value = "655.237.870-00";
            //  Wrong
            var value = "655.237.870-09";

            var result = value.isCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
        }
        #endregion
    }
}
