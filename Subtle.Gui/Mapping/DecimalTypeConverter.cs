using AutoMapper;

namespace Subtle.Gui.Mapping
{
    public class DecimalTypeConverter : TypeConverter<string, decimal?>
    {
        protected override decimal? ConvertCore(string source)
        {
            decimal result;
            decimal.TryParse(source, out result);

            // Discard zero values
            if (result == 0)
            {
                return null;
            }

            return result;
        }
    }
}
