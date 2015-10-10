using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class SubtitleFileCollection : OSDbResponse, IEnumerable<SubtitleFile>
    {
        [XmlRpcMember("data")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public SubtitleFile[] Files { get; set; }

        public IEnumerator<SubtitleFile> GetEnumerator()
        {
            return Files.Cast<SubtitleFile>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Files.GetEnumerator();
        }
    }
}
