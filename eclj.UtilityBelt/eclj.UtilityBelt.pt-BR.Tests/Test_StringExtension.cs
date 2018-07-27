using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace eclj.UtilityBelt.pt_BR.Tests
{
    [TestClass]
    public class Test_StringExtension
    {
        Type TYPE = typeof(StringExtension);

        #region Method KeyvaluePair<bool, string> isCPF(this string value)
        [DataTestMethod]
        [DataRow("206.846.060-20")]
        [DataRow("655.237.870-00")]
        [DataRow("336.082.320-60")]
        public void isCPF_success(string value)
        {
            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsTrue(result.Key, $"{value} should return true (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }

        [DataTestMethod]
        [DataRow("000.000.000-00")]
        [DataRow("111.111.111-11")]
        [DataRow("222.222.222-22")]
        [DataRow("333.333.333-33")]
        [DataRow("444.444.444-44")]
        [DataRow("555.555.555-55")]
        [DataRow("666.666.666-66")]
        [DataRow("777.777.777-77")]
        [DataRow("888.888.888-88")]
        [DataRow("999.999.999-99")]
        public void isCPF_error_knownInvalid(string value)
        {
            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void isCPF_error_nullOrEmpty(string value)
        {
            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }

        [DataTestMethod]
        [DataRow("655.")]
        [DataRow("655.237.870-0000000")]
        public void isCPF_error_notElevenCharacters(string value)
        {
            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }

        [TestMethod]
        public void isCPF_error_firstDigit()
        {
            //  Correct
            //value = "655.237.870-00";
            //  Wrong
            var value = "655.237.870-90";

            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }

        [TestMethod]
        public void isCPF_error_secondDigit()
        {
            //  Correct
            //value = "655.237.870-00";
            //  Wrong
            var value = "655.237.870-09";

            var result = value.isCPF();
            var resultText = TYPE.GetValueFromField(Utils.GetCurrentMethod(), null, BindingFlags.NonPublic | BindingFlags.Static);

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, resultText);
        }
        #endregion
    }
}
