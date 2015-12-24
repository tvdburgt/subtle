using System;
using AutoMapper;

namespace Subtle.Gui.Mapping
{
    public class DateTimeTypeConverter : TypeConverter<string, DateTime>
    {
        protected override DateTime ConvertCore(string source)
        {
            try
            {
                return System.Convert.ToDateTime(source);
            }
            catch (FormatException)
            {
                return DateTime.MinValue;
            }
        }
    }
}
