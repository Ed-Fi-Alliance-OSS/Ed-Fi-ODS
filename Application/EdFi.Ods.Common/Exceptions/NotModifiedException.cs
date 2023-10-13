// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Exceptions
{
    [Serializable]
    public class NotModifiedException : Exception
    {
        // For guidelines regarding the creation of new exception types, see
        //    https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions

        public NotModifiedException() { }

        public NotModifiedException(string message)
            : base(message) { }

        public NotModifiedException(string message, Exception inner)
            : base(message, inner) { }

        protected NotModifiedException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
