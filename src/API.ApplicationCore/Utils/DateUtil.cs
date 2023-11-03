using System;

namespace API.ApplicationCore
{
    public class DateUtil
    {
        public static DateTime GetCurrentDate() 
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
        }
    }
}
