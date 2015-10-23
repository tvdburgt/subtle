using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class SubtitleSearchResultCollection : OSDbResponse, IEnumerable<SubtitleSearchResult>
    {
        public SubtitleSearchResultCollection()
        {
            Results = new SubtitleSearchResult[0];
        }

        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public SubtitleSearchResult[] Results { get; set; }

        public IEnumerator<SubtitleSearchResult> GetEnumerator()
        {
            return Results.Cast<SubtitleSearchResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
