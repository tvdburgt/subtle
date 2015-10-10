using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class LanguageCollection : IEnumerable<Language>
    {
        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public Language[] Languages { get; set; }

        public IEnumerator<Language> GetEnumerator()
        {
            return Languages.Cast<Language>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Languages.GetEnumerator();
        }
    }
}
