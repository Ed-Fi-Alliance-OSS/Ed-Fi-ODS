// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;

namespace EdFi.Ods.Common.Models.Resource
{
    [Serializable]
    public class ProfileContentTypeException : Exception
    {
        public ProfileContentTypeException() { }

        public ProfileContentTypeException(string message)
            : base(message) { }

        public ProfileContentTypeException(string message, Exception inner)
            : base(message, inner) { }

        protected ProfileContentTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
