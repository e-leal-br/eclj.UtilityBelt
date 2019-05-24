namespace eclj.UtilityBelt
{
    using System;

    public static class DateTimeExtension
    {
        /// <summary>
        /// Verifies if a date is a weekend date.
        /// </summary>
        /// <param name="value">date to verify</param>
        /// <returns>true if is weekend, false if not</returns>
        public static bool IsWeekend(this DateTime value)
        {
            var result = false;

            if (value.DayOfWeek == DayOfWeek.Saturday)
                result = true;
            else if (value.DayOfWeek == DayOfWeek.Sunday)
                result = true;

            return result;
        }
    }
}
