// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Exceptions
{
    [Serializable]
    public class DatabaseConnectionException : Exception
    {
 
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
