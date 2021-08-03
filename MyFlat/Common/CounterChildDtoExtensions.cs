using MyFlat.Dto;
using System;
using System.Globalization;

namespace MyFlat.Common
{
    public static class CounterChildDtoExtensions
    {
        public static DateTime GetDate(this CounterChildDto element)
        {
            // Pattern: "2021-07-22 21:13:06.0"
            return DateTime.ParseExact(element.Dt_last_indication,
                "yyyy-MM-dd HH:mm:ss.f", CultureInfo.InvariantCulture);
        }
    }
}
