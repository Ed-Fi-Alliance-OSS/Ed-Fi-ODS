using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Exceptions
{
    [Serializable]
    public class MethodNotAllowedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MethodNotAllowedException() { }

        public MethodNotAllowedException(string message)
            : base(message) { }

        public MethodNotAllowedException(string message, Exception inner)
            : base(message, inner) { }

        protected MethodNotAllowedException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
