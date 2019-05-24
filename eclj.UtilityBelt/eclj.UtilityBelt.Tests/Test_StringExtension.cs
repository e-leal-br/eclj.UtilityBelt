using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eclj.UtilityBelt.Tests
{
    using eclj.UtilityBelt;

    [TestClass]
    public class Test_StringExtension
    {
        #region Method bool GetAlphaNumericCharacters(this string value)
        [DataTestMethod]
        [DataRow("Teste123")]
        [DataRow("123Teste")]
        [DataRow("123teste123")]
        public void GetAlphaNumericCharacters_WithNoCharactersToRemove(string value)
        {
            var result = value.GetAlphaNumericCharacters();

            Assert.AreEqual(result, value);
        }

        [DataTestMethod]
        [DataRow("T e|s&t¨e)1  23")]
        public void GetAlphaNumericCharacters_WithAnyCharactersToRemove(string value)
        {
            var result = value.GetAlphaNumericCharacters();

            Assert.AreEqual(result, "Teste123");
        }
        #endregion

        #region Method bool GetNumericCharacters(this string value)
        [DataTestMethod]
        [DataRow("12345")]
        [DataRow("54321")]
        public void GetNumericCharacters_WithNoCharactersToRemove(string value)
        {
            var result = value.GetNumericCharacters();

            Assert.AreEqual(result, value);
        }

        [DataTestMethod]
        [DataRow("123T e|s&t¨e)  45")]
        public void GetNumericCharacters_WithAnyCharactersToRemove(string value)
        {
            var result = value.GetNumericCharacters();

            Assert.AreEqual(result, "12345");
        }
        #endregion
    }
}