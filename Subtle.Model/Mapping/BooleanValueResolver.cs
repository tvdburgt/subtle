using AutoMapper;

namespace Subtle.Model.Mapping
{
    public class BooleanValueResolver : ValueResolver<string, bool>
    {
        protected override bool ResolveCore(string source)
        {
            return source == "1";
        }
    }
}
