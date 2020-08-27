// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Security
{
    [Serializable]
    public class EdFiSecurityException : Exception
    {
        public EdFiSecurityException() { }

        public EdFiSecurityException(string message)
            : base(message) { }

        public EdFiSecurityException(string message, string resource, string action)
            : base(message)
        {
            Resource = resource;
            Action = action;
        }

        public EdFiSecurityException(string message, string resource, string action, string apiKey)
            : base(message)
        {
            Resource = resource;
            Action = action;
            ApiKey = apiKey;
        }

        public EdFiSecurityException(string message, string resource, string action, string apiKey, Exception inner)
            : base(message, inner)
        {
            Resource = resource;
            Action = action;
            ApiKey = apiKey;
        }

        public EdFiSecurityException(string message, Exception inner)
            : base(message, inner) { }

        protected EdFiSecurityException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }

        public string ApiKey { get; }

        public string Resource { get; }

        public string Action { get; }
    }
}
