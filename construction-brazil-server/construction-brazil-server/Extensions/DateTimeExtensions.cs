namespace construction_brazil_server.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTimeOffset StripDateAndTime(this DateTimeOffset date, DateTimeOffset defaultValue, int offsetInMin = 0)
        {
            if (date == DateTimeOffset.MinValue)
                return defaultValue;

            var strippedDate = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, TimeSpan.Zero);

            if (offsetInMin > 0)
                strippedDate = strippedDate.ToOffset(new TimeSpan(0, offsetInMin, 0));

            return strippedDate;
        }

        public static DateTimeOffset StripDateAndTime(this DateTimeOffset? date, DateTimeOffset defaultValue, int offsetInMin = 0)
        {
            if (date == null || date == DateTimeOffset.MinValue)
                return defaultValue;

            var parsedDate = date ?? defaultValue;

            var strippedDate = new DateTimeOffset(parsedDate.Year, parsedDate.Month, parsedDate.Day, 0, 0, 0, TimeSpan.Zero);

            if (offsetInMin > 0)
                strippedDate = strippedDate.ToOffset(new TimeSpan(0, offsetInMin, 0));

            return strippedDate;
        }

        public static bool IsMinDbValue(this DateTimeOffset date)
        {
            return date == new DateTimeOffset(1900, 1, 1, 0, 0, 0, TimeSpan.Zero);
        }

        public static DateTime StripDateAndTime(this DateTime? date, DateTime defaultValue)
        {
            if (date == null || date == DateTime.MinValue)
                return defaultValue;

            var parsedDate = date ?? defaultValue;

            var strippedDate = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, 0, 0, 0);

            return strippedDate;
        }

        public static DateTime StripDateAndTime(this DateTime date, DateTime defaultValue)
        {
            if (date == DateTime.MinValue)
                return defaultValue;

            var strippedDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

            return strippedDate;
        }

    }
}
