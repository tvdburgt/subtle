using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class ImdbSearchResultCollection : IEnumerable<ImdbSearchResult>
    {
        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public ImdbSearchResult[] Results { get; set; }

        [XmlRpcMember("status")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public string Status { get; set; }

        public IEnumerator<ImdbSearchResult> GetEnumerator()
        {
            return Results.Cast<ImdbSearchResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Results.GetEnumerator();
        }
    }
}
