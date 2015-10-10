using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class SubtitleSearchResultCollection : OSDbResponse, IEnumerable<SubtitleSearchResult>
    {
        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public SubtitleSearchResult[] Results { get; set; }

        public IEnumerator<SubtitleSearchResult> GetEnumerator()
        {
            return Results.Cast<SubtitleSearchResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Results.GetEnumerator();
        }
    }
}
