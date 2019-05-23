namespace eclj.UtilityBelt.pt_BR
{
    using eclj.UtilityBelt.pt_BR.Localization;
    using System;
    using System.Collections.Generic;

    public static class StringExtension
    {
        private const int LENGTH_CPF = 11;
        private const int LENGTH_CNPJ = 14;

        /// <summary>
        /// Validates if a string is a valid CPF.
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns>true if valid, false if not valid, and the following reason</returns>
        public static KeyValuePair<bool, string> isCPF(this string value)
        {
            var result = new KeyValuePair<bool, string>(false, Resource.isCPF_error_default);

            try
            {
                //  Check if value is null or empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception(Resource.isCPF_error_nullOrEmpty);

                //  Get only alphanumeric characters from string
                var valueAlphaNumeric = value.getAlphaNumericCharacters();
                //  Get only numeric characters from string
                var valueNumeric = value.getNumericCharacters();

                //  Check if value is null or empty
                if (string.IsNullOrEmpty(valueAlphaNumeric) ||
                    string.IsNullOrEmpty(valueNumeric))
                    throw new Exception(Resource.isCPF_error_nullOrEmpty);

                //  Check if value contain any characters but numbers
                if (valueAlphaNumeric != valueNumeric)
                    throw new Exception(Resource.isCPF_error_invalidCharacters);

                value = valueNumeric;

                //  Check if value has eleven characters (valid CPF)
                if (value.Length != LENGTH_CPF)
                    throw new Exception(Resource.isCPF_error_notElevenCharacters);

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
                        throw new Exception(Resource.isCPF_error_knownInvalid);
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

                for (int i = 0, multiplier = 10; multiplier >= 2; i++, multiplier--)
                    firstDigitSum = firstDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                //  Now we need to multiply the sum result by 10
                firstDigitSum = firstDigitSum * 10;

                //  Now we need to get the rest of the division by 11
                firstDigitVerifier = firstDigitSum % 11;

                //  If we get 10 as rest, that means we should use 0
                if (firstDigitVerifier == 10)
                    firstDigitVerifier = 0;

                if (firstDigit != firstDigitVerifier)
                    throw new Exception(Resource.isCPF_error_firstDigit);
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

                for (int i = 0, multiplier = 11; multiplier >= 2; i++, multiplier--)
                    secondDigitSum = secondDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                //  Now we need to multiply the sum result by 10
                secondDigitSum = secondDigitSum * 10;

                //  Now we need to get the rest of the division by 11
                secondDigitVerifier = secondDigitSum % 11;

                //  If we get 10 as rest, that means we should use 0
                if (secondDigitVerifier == 10)
                    secondDigitVerifier = 0;

                if (secondDigit != secondDigitVerifier)
                    throw new Exception(Resource.isCPF_error_secondDigit);
                #endregion

                result = new KeyValuePair<bool, string>(true, Resource.isCPF_success);
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Validates if a string is a valid CNPJ.
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns>true if valid, false if not valid, and the following reason</returns>
        public static KeyValuePair<bool, string> isCNPJ(this string value)
        {
            var result = new KeyValuePair<bool, string>(false, Resource.isCNPJ_error_default);

            try
            {
                //  Check if value is null or empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception(Resource.isCNPJ_error_nullOrEmpty);

                //  Get only alphanumeric characters from string
                var valueAlphaNumeric = value.getAlphaNumericCharacters();
                //  Get only numeric characters from string
                var valueNumeric = value.getNumericCharacters();

                //  Check if value is null or empty
                if (string.IsNullOrEmpty(valueAlphaNumeric) ||
                    string.IsNullOrEmpty(valueNumeric))
                    throw new Exception(Resource.isCNPJ_error_nullOrEmpty);

                //  Check if value contain any characters but numbers
                if (valueAlphaNumeric != valueNumeric)
                    throw new Exception(Resource.isCNPJ_error_invalidCharacters);

                value = valueNumeric;

                //  Check if value has fourteen characters (valid CNPJ)
                if (value.Length != LENGTH_CNPJ)
                    throw new Exception(Resource.isCNPJ_error_notFourteenCharacters);

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

                for (int i = 0, multiplier = 5; multiplier >= 2; i++, multiplier--)
                    firstDigitSum = firstDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                for (int i = 4, multiplier = 9; multiplier >= 2; i++, multiplier--)
                    firstDigitSum = firstDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                //  Now we need to get the rest of the division by 11
                firstDigitVerifier = firstDigitSum % 11;

                //  If we get less than 2 as rest, that means we should use 0
                //  otherwise we should subtract the rest from eleven
                if (firstDigitVerifier < 2)
                    firstDigitVerifier = 0;
                else
                    firstDigitVerifier = 11 - firstDigitVerifier;

                if (firstDigit != firstDigitVerifier)
                    throw new Exception(Resource.isCNPJ_error_firstDigit);
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

                for (int i = 0, multiplier = 6; multiplier >= 2; i++, multiplier--)
                    secondDigitSum = secondDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                for (int i = 5, multiplier = 9; multiplier >= 2; i++, multiplier--)
                    secondDigitSum = secondDigitSum + (Convert.ToInt16(value[i].ToString()) * multiplier);

                //  Now we need to get the rest of the division by 11
                secondDigitVerifier = secondDigitSum % 11;

                //  If we get less than 2 as rest, that means we should use 0
                //  otherwise we should subtract the rest from eleven
                if (secondDigitVerifier < 2)
                    secondDigitVerifier = 0;
                else
                    secondDigitVerifier = 11 - secondDigitVerifier;

                if (secondDigit != secondDigitVerifier)
                    throw new Exception(Resource.isCNPJ_error_secondDigit);
                #endregion

                result = new KeyValuePair<bool, string>(true, Resource.isCNPJ_success);
            }
            catch (Exception ex)
            {
                result = new KeyValuePair<bool, string>(false, ex.Message);
            }

            return result;
        }
    }
}
