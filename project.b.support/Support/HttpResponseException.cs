using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.support.Support
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class HttpResponseException : Exception
    {
        private HttpResponseException()
        {
        }
        public HttpResponseException(string message)
          : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

