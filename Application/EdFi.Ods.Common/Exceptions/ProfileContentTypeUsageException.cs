// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Runtime.Serialization;
using EdFi.Ods.Common.Utils.Profiles;

namespace EdFi.Ods.Common.Exceptions;

public class ProfileContentTypeUsageException : Exception
{
    public ProfileContentTypeUsageException() { }

    public ProfileContentTypeUsageException(string message, string profileName, ContentTypeUsage contentTypeUsage)
        : base(message)
    {
        ProfileName = profileName;
        ContentTypeUsage = contentTypeUsage;
    }

    public ProfileContentTypeUsageException(string message, string profileName, ContentTypeUsage contentTypeUsage, Exception innerException)
        : base(message, innerException)
    {
        ProfileName = profileName;
        ContentTypeUsage = contentTypeUsage;
    }

    protected ProfileContentTypeUsageException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public string ProfileName { get; }

    public ContentTypeUsage ContentTypeUsage { get; }
}
