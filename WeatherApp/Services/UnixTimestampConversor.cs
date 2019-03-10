using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public class UnixTimestampConversor
    {
        public DateTime GetDateTime(long unixDateTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.ToLocalTime();
        }

        public long GetUnixTimestamp(DateTime dateTime)
        {
            var dateTimeOffset = new DateTimeOffset(dateTime);
            return dateTimeOffset.ToUnixTimeSeconds();
        }
    }
}
