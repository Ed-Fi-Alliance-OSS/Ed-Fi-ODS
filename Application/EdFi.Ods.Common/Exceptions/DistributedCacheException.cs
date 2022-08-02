// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Exceptions
{
    [Serializable]
    public class DistributedCacheException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DistributedCacheException() { }

        public DistributedCacheException(string message)
            : base(message) { }

        public DistributedCacheException(string message, Exception inner)
            : base(message, inner) { }

        protected DistributedCacheException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class SafeDistributedCacheException : DistributedCacheException
    {
        public override string StackTrace => "See log for details";

        public SafeDistributedCacheException(string message)
            : base(message) { }
    }
}