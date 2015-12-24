using AutoMapper;

namespace Subtle.Gui.Mapping
{
    public class BooleanValueResolver : ValueResolver<string, bool>
    {
        protected override bool ResolveCore(string source)
        {
            return source == "1";
        }
    }
}
