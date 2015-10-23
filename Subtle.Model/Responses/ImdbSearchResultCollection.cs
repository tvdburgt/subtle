using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class ImdbSearchResultCollection : OSDbResponse, IEnumerable<ImdbSearchResult>
    {
        public ImdbSearchResultCollection()
        {
            Results = new ImdbSearchResult[0];
        }

        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public ImdbSearchResult[] Results { get; set; }

        public IEnumerator<ImdbSearchResult> GetEnumerator()
        {
            return Results.Cast<ImdbSearchResult>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
