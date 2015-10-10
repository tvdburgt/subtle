using System.Net;
using CookComputing.XmlRpc;

namespace Subtle.Model.Responses
{
    public abstract class OSDbResponse
    {
        [XmlRpcMember("status")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public string Status { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public HttpStatusCode StatusCode
        {
            get
            {
                int code = int.Parse(Status.Split(' ')[0]);
                return (HttpStatusCode)code;
            }
        }

        /// <summary>
        /// Server execution time in seconds
        /// </summary>
        [XmlRpcMember("seconds")]
        [XmlRpcMissingMapping(MappingAction.Error)]
        public double ServerTime { get; set; }
    }
}
