using System;
using AutoMapper;

namespace Subtle.UI.Mapping
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(ResolutionContext context)
        {
            if (context.SourceValue == null)
            {
                return DateTime.MinValue;
            }

            try
            {
                return System.Convert.ToDateTime(context.SourceValue);
            }
            catch (FormatException)
            {
                return DateTime.MinValue;
            }
        }
    }
}
