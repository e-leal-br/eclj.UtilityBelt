namespace eclj.UtilityBelt.pt_BR
{
    using System;
    using System.Collections.Generic;

    public static class StringExtension
    {
        private const int LENGTH_CPF = 11;
        private const int LENGTH_CNPJ = 14;

        private const string isCPF_success = "Value is a valid CPF.";
        private const string isCPF_error_default = "Unknown error.";
        private const string isCPF_error_knownInvalid = "Value is a known invalid CPF.";
        private const string isCPF_error_invalidCharacters = "Value contain invalid characters.";
        private const string isCPF_error_nullOrEmpty = "Value is null or empty.";
        private const string isCPF_error_notElevenCharacters = "Value does not contain eleven characters.";
        private const string isCPF_error_firstDigit = "The first digit of value is not equal to the first digit verifier.";
        private const string isCPF_error_secondDigit = "The second digit of value is not equal to the second digit verifier.";

        /// <summary>
        /// Validates if a string is a valid CPF.
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns>true if valid, false if not valid, and the following reason</returns>
        public static KeyValuePair<bool, string> isCPF(this string value)
        {
            var result = new KeyValuePair<bool, string>(false, isCPF_error_default);

            try
            {
                //  Check if value is null or empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception(isCPF_error_nullOrEmpty);

                //  Get only alphanumeric characters from string
                var valueAlphaNumeric = value.getAlphaNumericCharacters();
                //  Get only numeric characters from string
                var valueNumeric = value.getNumericCharacters();

                //  Check if value is null or empty
                if (string.IsNullOrEmpty(valueAlphaNumeric) ||
                    string.IsNullOrEmpty(valueNumeric))
                    throw new Exception(isCPF_error_nullOrEmpty);

                //  Check if value contain any characters but numbers
                if (valueAlphaNumeric != valueNumeric)
                    throw new Exception(isCPF_error_invalidCharacters);

                value = valueNumeric;

                //  Check if value has eleven characters (valid CPF)
                if (value.Length != LENGTH_CPF)
                    throw new Exception(isCPF_error_notElevenCharacters);

                #region Known Invalid Values
                switch (value)
                {
                    case "00000000000":
                    case "11111111111":
                    case "22222222222":
                    case "33333333333":
                    case "44444444444":
                    case "55555555555":
                    case "66666666666":
                    case "77777777777":
                    case "88888888888":
                    case "99999999999":
                        throw new Exception(isCPF_error_knownInvalid);
                }
                #endregion

                #region First Digit Validation
                //  Consists on multipling the first nine digits
                //  with the following formula:
                //  - 1º number by 10
                //  - 2º number by 9
                //  - 3º number by 8
                //  - and so on to the 9º number by 2
                var firstDigit = Convert.ToInt16(value[9].ToString());
                var firstDigitVerifier = (int)0;
                var firstDigitSum = (int)0;

                var firstValueInt = (int)0;

                firstValueInt = Convert.ToInt16(value[0].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 10);
                firstValueInt = Convert.ToInt16(value[1].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 9);
                firstValueInt = Convert.ToInt16(value[2].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 8);
                firstValueInt = Convert.ToInt16(value[3].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 7);
                firstValueInt = Convert.ToInt16(value[4].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 6);
                firstValueInt = Convert.ToInt16(value[5].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 5);
                firstValueInt = Convert.ToInt16(value[6].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 4);
                firstValueInt = Convert.ToInt16(value[7].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 3);
                firstValueInt = Convert.ToInt16(value[8].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 2);
                
                //  Now we need to multiply the sum result by 10
                firstDigitSum = firstDigitSum * 10;

                //  Now we need to get the rest of the division by 11
                firstDigitVerifier = firstDigitSum % 11;

                //  If we get 10 as rest, that means we should use 0
                if (firstDigitVerifier == 10)
                    firstDigitVerifier = 0;

                if (firstDigit != firstDigitVerifier)
                    throw new Exception(isCPF_error_firstDigit);
                #endregion

                #region Second Digit Validation
                //  Consists on multipling the first nine digits
                //  with the following formula:
                //  - 1º number by 11
                //  - 2º number by 9
                //  - 3º number by 8
                //  - and so on to the 10º number by 2
                var secondDigit = Convert.ToInt16(value[10].ToString());
                var secondDigitVerifier = (int)0;
                var secondDigitSum = (int)0;

                var secondfirstValueInt = (int)0;

                secondfirstValueInt = Convert.ToInt16(value[0].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 11);
                secondfirstValueInt = Convert.ToInt16(value[1].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 10);
                secondfirstValueInt = Convert.ToInt16(value[2].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 9);
                secondfirstValueInt = Convert.ToInt16(value[3].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 8);
                secondfirstValueInt = Convert.ToInt16(value[4].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 7);
                secondfirstValueInt = Convert.ToInt16(value[5].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 6);
                secondfirstValueInt = Convert.ToInt16(value[6].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 5);
                secondfirstValueInt = Convert.ToInt16(value[7].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 4);
                secondfirstValueInt = Convert.ToInt16(value[8].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 3);
                secondfirstValueInt = Convert.ToInt16(value[9].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 2);
                
                //  Now we need to multiply the sum result by 10
                secondDigitSum = secondDigitSum * 10;

                //  Now we need to get the rest of the division by 11
                secondDigitVerifier = secondDigitSum % 11;

                //  If we get 10 as rest, that means we should use 0
                if (secondDigitVerifier == 10)
                    secondDigitVerifier = 0;

                if (secondDigit != secondDigitVerifier)
                    throw new Exception(isCPF_error_secondDigit);
                #endregion

                result = new KeyValuePair<bool, string>(true, isCPF_success);
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }

            return result;
        }

        private const string isCNPJ_success = "Value is a valid CNPJ.";
        private const string isCNPJ_error_default = "Unknown error.";
        private const string isCNPJ_error_invalidCharacters = "Value contain invalid characters.";
        private const string isCNPJ_error_nullOrEmpty = "Value is null or empty.";
        private const string isCNPJ_error_notFourteenCharacters = "Value does not contain fourteen characters.";
        private const string isCNPJ_error_firstDigit = "The first digit of value is not equal to the first digit verifier.";
        private const string isCNPJ_error_secondDigit = "The second digit of value is not equal to the second digit verifier.";

        /// <summary>
        /// Validates if a string is a valid CNPJ.
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns>true if valid, false if not valid, and the following reason</returns>
        public static KeyValuePair<bool, string> isCNPJ(this string value)
        {
            var result = new KeyValuePair<bool, string>(false, isCPF_error_default);

            try
            {
                //  Check if value is null or empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception(isCNPJ_error_nullOrEmpty);

                //  Get only alphanumeric characters from string
                var valueAlphaNumeric = value.getAlphaNumericCharacters();
                //  Get only numeric characters from string
                var valueNumeric = value.getNumericCharacters();

                //  Check if value is null or empty
                if (string.IsNullOrEmpty(valueAlphaNumeric) ||
                    string.IsNullOrEmpty(valueNumeric))
                    throw new Exception(isCNPJ_error_nullOrEmpty);

                //  Check if value contain any characters but numbers
                if (valueAlphaNumeric != valueNumeric)
                    throw new Exception(isCNPJ_error_invalidCharacters);

                value = valueNumeric;

                //  Check if value has fourteen characters (valid CNPJ)
                if (value.Length != LENGTH_CNPJ)
                    throw new Exception(isCNPJ_error_notFourteenCharacters);

                #region First Digit Validation
                //  Consists on multipling the first twelve digits
                //  with the following formula:
                //  - 1º number by 5
                //  - 2º number by 4
                //  - 3º number by 3
                //  - 4º number by 2
                //  - 5º number by 9
                //  - 6º number by 8
                //  - and so on to the 12º number by 2
                var firstDigit = Convert.ToInt16(value[12].ToString());
                var firstDigitVerifier = (int)0;
                var firstDigitSum = (int)0;

                var firstValueInt = (int)0;

                firstValueInt = Convert.ToInt16(value[0].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 5);
                firstValueInt = Convert.ToInt16(value[1].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 4);
                firstValueInt = Convert.ToInt16(value[2].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 3);
                firstValueInt = Convert.ToInt16(value[3].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 2);
                firstValueInt = Convert.ToInt16(value[4].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 9);
                firstValueInt = Convert.ToInt16(value[5].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 8);
                firstValueInt = Convert.ToInt16(value[6].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 7);
                firstValueInt = Convert.ToInt16(value[7].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 6);
                firstValueInt = Convert.ToInt16(value[8].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 5);
                firstValueInt = Convert.ToInt16(value[9].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 4);
                firstValueInt = Convert.ToInt16(value[10].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 3);
                firstValueInt = Convert.ToInt16(value[11].ToString());
                firstDigitSum = firstDigitSum + (firstValueInt * 2);
                
                //  Now we need to get the rest of the division by 11
                firstDigitVerifier = firstDigitSum % 11;

                //  If we get less than 2 as rest, that means we should use 0
                //  otherwise we should subtract the rest from eleven
                if (firstDigitVerifier < 2)
                    firstDigitVerifier = 0;
                else
                    firstDigitVerifier = 11 - firstDigitVerifier;

                if (firstDigit != firstDigitVerifier)
                    throw new Exception(isCNPJ_error_firstDigit);
                #endregion

                #region Second Digit Validation
                //  Consists on multipling the first thirteen digits
                //  with the following formula:
                //  - 1º number by 6
                //  - 2º number by 5
                //  - 3º number by 4
                //  - 4º number by 3
                //  - 5º number by 2
                //  - 6º number by 9
                //  - 7º number by 8
                //  - and so on to the 13º number by 2
                var secondDigit = Convert.ToInt16(value[13].ToString());
                var secondDigitVerifier = (int)0;
                var secondDigitSum = (int)0;

                var secondfirstValueInt = (int)0;

                secondfirstValueInt = Convert.ToInt16(value[0].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 6);
                secondfirstValueInt = Convert.ToInt16(value[1].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 5);
                secondfirstValueInt = Convert.ToInt16(value[2].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 4);
                secondfirstValueInt = Convert.ToInt16(value[3].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 3);
                secondfirstValueInt = Convert.ToInt16(value[4].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 2);
                secondfirstValueInt = Convert.ToInt16(value[5].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 9);
                secondfirstValueInt = Convert.ToInt16(value[6].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 8);
                secondfirstValueInt = Convert.ToInt16(value[7].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 7);
                secondfirstValueInt = Convert.ToInt16(value[8].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 6);
                secondfirstValueInt = Convert.ToInt16(value[9].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 5);
                secondfirstValueInt = Convert.ToInt16(value[10].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 4);
                secondfirstValueInt = Convert.ToInt16(value[11].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 3);
                secondfirstValueInt = Convert.ToInt16(value[12].ToString());
                secondDigitSum = secondDigitSum + (secondfirstValueInt * 2);
                
                //  Now we need to get the rest of the division by 11
                secondDigitVerifier = secondDigitSum % 11;

                //  If we get less than 2 as rest, that means we should use 0
                //  otherwise we should subtract the rest from eleven
                if (secondDigitVerifier < 2)
                    secondDigitVerifier = 0;
                else
                    secondDigitVerifier = 11 - secondDigitVerifier;

                if (secondDigit != secondDigitVerifier)
                    throw new Exception(isCNPJ_error_secondDigit);
                #endregion

                result = new KeyValuePair<bool, string>(true, isCNPJ_success);
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }

            return result;
        }
    }
}
