using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public abstract class OSDbResponse
    {
        [XmlRpcMember("status")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public string Status { get; set; }

        /// <summary>
        /// Server execution time in seconds
        /// </summary>
        [XmlRpcMember("seconds")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public double ServerTime { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public bool IsSuccess => Status.StartsWith("200 OK");
    }
}
