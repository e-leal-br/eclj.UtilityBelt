﻿namespace eclj.UtilityBelt
{
    using System;
    using System.Linq;

    public static class StringExtension
    {
        /// <summary>
        /// Returns the alphanumeric (letters and numbers) characters of a string.
        /// </summary>
        public static string getAlphaNumericCharacters(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value))
            {
                result = new String(result.Where(Char.IsLetterOrDigit).ToArray());
            }

            return result;
        }

        /// <summary>
        /// Returns the non alphanumeric (not letters and numbers) characters of a string.
        /// </summary>
        public static string getNonAlphaNumericCharacters(this string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the numeric (numbers) characters of a string.
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