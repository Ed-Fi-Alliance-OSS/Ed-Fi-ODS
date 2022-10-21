// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using EdFi.Common.Inflection;
using Microsoft.Extensions.Primitives;

namespace EdFi.Ods.Common.Utils.Profiles
{
    public static class ProfilesContentTypeHelper
    {
        private static readonly ConcurrentDictionary<ContentTypeKey, string> _contentTypeByKey = new();

        public static string CreateContentType(
            string resourceName,
            string profileName,
            ContentTypeUsage usage)
        {
            return _contentTypeByKey.GetOrAdd(
                new ContentTypeKey(resourceName, profileName, usage),
                key => string.Format(
                    "application/vnd.ed-fi.{0}.{1}.{2}+json",
                    resourceName.ToLower(),
                    profileName.ToLower(),
                    usage.ToString().ToLower()));
        }

        private struct ContentTypeKey
        {
            public ContentTypeKey(string resourceName, string profileName, ContentTypeUsage contentTypeUsage)
            {
                ResourceName = resourceName;
                ProfileName = profileName;
                ContentTypeUsage = contentTypeUsage;
            }

            public string ResourceName { get; }

            public string ProfileName { get; private set; }

            public ContentTypeUsage ContentTypeUsage { get; private set; }
        }
    }
}
