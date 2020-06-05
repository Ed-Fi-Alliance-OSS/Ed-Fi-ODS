// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Api.Common.OperationalContext.PersonIdentification
{
    /// <summary>
    /// Thrown when the client-supplied unique Id value resolves to multiple people.
    /// </summary>
    [Serializable]
    public class AmbiguousUniqueIdMatchException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public AmbiguousUniqueIdMatchException() { }

        public AmbiguousUniqueIdMatchException(string message)
            : base(message) { }

        public AmbiguousUniqueIdMatchException(string message, Exception inner)
            : base(message, inner) { }

        protected AmbiguousUniqueIdMatchException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
