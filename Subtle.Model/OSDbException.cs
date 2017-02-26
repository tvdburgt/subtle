using System;
using Subtle.Model.Responses;

namespace Subtle.Model
{
    public class OSDbException : Exception
    {
        public OSDbException(OSDbResponse response)
            : this(response.Status)
        {
        }

        public OSDbException(string message)
            : base(message)
        {
        }

        public OSDbException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}