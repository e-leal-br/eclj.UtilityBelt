namespace eclj.UtilityBelt
{
    using System;
    using System.Linq;

    public static class StringExtension
    {
        /// <summary>
        /// Return the letters and numeric characters from a string.
        /// </summary>
        public static string getAlphanumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
            {
                result = new String(result.Where(Char.IsLetterOrDigit).ToArray());
            }

            return result;
        }

        /// <summary>
        /// Return the numeric characters from a string.
        /// </summary>
        public static string getNumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
            {
                result = new String(result.Where(Char.IsDigit).ToArray());
            }

            return result;
        }
    }
}
