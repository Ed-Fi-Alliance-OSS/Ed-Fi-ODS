// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Inflection;

namespace EdFi.Ods.Common.Utils.Profiles
{
    public static class ProfilesContentTypeHelper
    {
        private static readonly Regex ProfileRegex = new Regex(
            @"^application/vnd\.ed-fi(\.(?<Implementation>[\w\-]+))?\.(?<Resource>\w+)\.(?<Profile>[\w\-]+)\.(?<Usage>(readable|writable))\+json$",
            RegexOptions.Compiled);

        public static string CreateContentType(
            string resourceCollectionName,
            string profileName,
            ContentTypeUsage usage)
        {
            return string.Format(
                "application/vnd.ed-fi{0}.{1}.{2}.{3}+json",
                string.Empty,
                CompositeTermInflector.MakeSingular(resourceCollectionName)
                                      .ToLower(),
                profileName.ToLower(),
                usage.ToString()
                     .ToLower());
        }

        public static ProfileContentTypeDetails GetContentTypeDetails(this string contentType)
        {
            ProfileContentTypeDetails details;

            if (TryGetContentTypeDetails(contentType, out details))
            {
                return details;
            }

            return null;
        }

        public static bool IsEdFiContentType(this string contentType)
        {
            if (contentType.StartsWith("application/vnd.ed-fi."))
            {
                return true;
            }

            return false;
        }

        public static bool TryGetContentTypeDetails(this string contentType, out ProfileContentTypeDetails details)
        {
            details = null;

            var match = ProfileRegex.Match(contentType);

            if (!match.Success)
            {
                return false;
            }

            details = new ProfileContentTypeDetails
                      {
                          Implementation = match.Groups["Implementation"]
                                                .Value,
                          Resource = match.Groups["Resource"]
                                          .Value,
                          Profile = match.Groups["Profile"]
                                         .Value,
                          Usage =
                              (ContentTypeUsage) Enum.Parse(
                                  typeof(ContentTypeUsage),
                                  match.Groups["Usage"]
                                       .Value,
                                  true)
                      };

            return true;
        }
    }
}
