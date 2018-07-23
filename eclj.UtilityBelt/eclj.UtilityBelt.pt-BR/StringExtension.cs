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
        private const string isCPF_error_nullOrEmpty = "Value is null or empty.";
        private const string isCPF_error_notElevenCharacters = "Value does not contain eleven characters.";
        private const string isCPF_error_firstDigit = "The first digit of value is not equal to the first digit verifier.";
        private const string isCPF_error_secondDigit = "The second digit of value is not equal to the second digit verifier.";

        /// <summary>
        /// This method validates if a string is a valid CPF.
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

                //  Get only numeric characters from string
                value = value.getNumericCharacters();

                //  Check if value is null or empty
                if (string.IsNullOrEmpty(value))
                    throw new Exception(isCPF_error_nullOrEmpty);

                //  Check if value has eleven characters (valid CPF)
                if (value.Length != LENGTH_CPF)
                    throw new Exception(isCPF_error_notElevenCharacters);

                #region First Digit Validation
                //  Consists on multipling the first nine digits
                //  with the following formula:
                //  - 1º number by 10
                //  - 2º number by 9
                //  - 3º number by 8
                //  - and so on to the 9º number by 2
                var firstDigit = (int)value[9];
                var firstDigitVerifier = (int)0;
                var firstDigitSum = (int)0;

                for (int i = 0; i < value.Length - 2; i++)
                {
                    firstDigitSum = firstDigitSum + (((int)value[i]) * (i + (value.Length - i)));
                }

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
                var secondDigit = Convert.ToInt32(value[10]);
                var secondDigitVerifier = (int)0;
                var secondDigitSum = (int)0;

                for (int i = 0; i < value.Length - 1; i++)
                {
                    secondDigitSum = secondDigitSum + (((int)value[i]) * (i + (value.Length - i)));
                }

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

        public static bool isCNPJ(this string value)
        {
            throw new NotImplementedException();
        }
    }
}
