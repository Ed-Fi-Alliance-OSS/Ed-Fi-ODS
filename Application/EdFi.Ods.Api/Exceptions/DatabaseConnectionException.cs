using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Exceptions
{
    [Serializable]
    public class DatabaseConnectionException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DatabaseConnectionException() { }

        public DatabaseConnectionException(string message)
            : base(message) { }

        public DatabaseConnectionException(string message, Exception inner)
            : base(message, inner) { }

        protected DatabaseConnectionException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
