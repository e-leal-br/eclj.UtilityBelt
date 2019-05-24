using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eclj.UtilityBelt.pt_BR.Tests
{
    using eclj.UtilityBelt.pt_BR.Localization;

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
            var result = value.IsCPF();

            Assert.IsTrue(result.Key, $"{value} should return true (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_success);
        }

        [DataTestMethod]
        [DataRow("206.abc.060-20")]
        [DataRow("abc206.846.060-20")]
        public void isCPF_error_invalidCharacters(string value)
        {
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_invalidCharacters);
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
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_knownInvalid);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void isCPF_error_nullOrEmpty(string value)
        {
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_nullOrEmpty);
        }

        [DataTestMethod]
        [DataRow("655.")]
        [DataRow("655.237.870-0000000")]
        public void isCPF_error_notElevenCharacters(string value)
        {
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_notElevenCharacters);
        }

        [DataTestMethod]
        //[DataRow("206.846.060-20")]
        [DataRow("206.846.060-30")]
        //[DataRow("655.237.870-00")]
        [DataRow("655.237.870-10")]
        //[DataRow("336.082.320-60")]
        [DataRow("336.082.320-70")]
        public void isCPF_error_firstDigit(string value)
        {
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_firstDigit);
        }

        [DataTestMethod]
        //[DataRow("206.846.060-20")]
        [DataRow("206.846.060-21")]
        //[DataRow("655.237.870-00")]
        [DataRow("655.237.870-01")]
        //[DataRow("336.082.320-60")]
        [DataRow("336.082.320-61")]
        public void isCPF_error_secondDigit(string value)
        {
            var result = value.IsCPF();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCPF_error_secondDigit);
        }
        #endregion

        #region Method KeyvaluePair<bool, string> isCNPJ(this string value)
        [DataTestMethod]
        [DataRow("85.876.486/0001-89")]
        [DataRow("19.799.418/0001-39")]
        [DataRow("18.964.930/0001-20")]
        public void isCNPJ_success(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsTrue(result.Key, $"{value} should return true (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_success);
        }

        [DataTestMethod]
        [DataRow("18.964.abc/0001-20")]
        [DataRow("abc18.964.930/0001-20")]
        public void isCNPJ_error_invalidCharacters(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_error_invalidCharacters);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void isCNPJ_error_nullOrEmpty(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_error_nullOrEmpty);
        }

        [DataTestMethod]
        [DataRow("85.876.486/0001-")]
        [DataRow("85.876.486/0001-890000")]
        public void isCNPJ_error_notFourteenCharacters(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_error_notFourteenCharacters);
        }

        [DataTestMethod]
        //[DataRow("85.876.486/0001-89")]
        [DataRow("85.876.486/0001-99")]
        //[DataRow("19.799.418/0001-39")]
        [DataRow("19.799.418/0001-49")]
        //[DataRow("18.964.930/0001-20")]
        [DataRow("18.964.930/0001-30")]
        public void isCNPJ_error_firstDigit(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_error_firstDigit);
        }

        [DataTestMethod]
        //[DataRow("85.876.486/0001-89")]
        [DataRow("85.876.486/0001-80")]
        //[DataRow("19.799.418/0001-39")]
        [DataRow("19.799.418/0001-30")]
        //[DataRow("18.964.930/0001-20")]
        [DataRow("18.964.930/0001-21")]
        public void isCNPJ_error_secondDigit(string value)
        {
            var result = value.IsCNPJ();

            Assert.IsFalse(result.Key, $"{value} should return false (returning message: '{result.Value}').");
            Assert.AreEqual(result.Value, Resource.isCNPJ_error_secondDigit);
        }
        #endregion
    }
}
