namespace eclj.UtilityBelt
{
    using System.Linq;

    public static class StringExtension
    {
        /// <summary>
        /// Returns the alphanumeric (letters and numbers) characters of a string.
        /// </summary>
        /// <param name="value">string to manipulate</param>
        /// <returns>the string with only alphanumeric (letters and numbers) characters</returns>
        public static string GetAlphaNumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
                result = new string(result.Where(c => char.IsLetterOrDigit(c)).ToArray());

            return result;
        }

        /// <summary>
        /// Returns the non alphanumeric (not letters and numbers) characters of a string.
        /// </summary>
        /// <param name="value">string to manipulate</param>
        /// <returns>the string with only non alphanumeric (not letters and numbers) characters</returns>
        public static string GetNonAlphaNumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
                result = new string(result.Where(c => !char.IsLetterOrDigit(c)).ToArray());

            return result;
        }

        /// <summary>
        /// Returns the numeric (numbers) characters of a string.
        /// </summary>
        /// <param name="value">string to manipulate</param>
        /// <returns>the string with only numeric (numbers) characters</returns>
        public static string GetNumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
                result = new string(result.Where(c => char.IsDigit(c)).ToArray());

            return result;
        }
    }
}
