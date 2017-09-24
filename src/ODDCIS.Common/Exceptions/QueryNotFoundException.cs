using System;
using System.Runtime.Serialization;

namespace ODDCIS.Common.Exceptions
{
    public class QueryNotFoundException : Exception
    {
        public QueryNotFoundException() : base("Query file not found")
        {
        }

        public QueryNotFoundException(string message) : base(message)
        {

        }

        public QueryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QueryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
