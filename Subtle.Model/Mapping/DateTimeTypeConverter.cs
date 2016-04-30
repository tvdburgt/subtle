using System;
using AutoMapper;
using System.Globalization;

namespace Subtle.Model.Mapping
{
    public class DateTimeTypeConverter : TypeConverter<string, DateTime>
    {
        protected override DateTime ConvertCore(string source)
        {
            DateTime result;
            DateTime.TryParse(source, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result);
            return result;
        }
    }
}
