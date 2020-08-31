// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;

namespace EdFi.Ods.Features.OpenApiMetadata
{
    public static class OpenApiStringExtensions
    {
        public static string EnhanceResourceDescription(this string description, bool isDeprecated, string[] deprecationReasons)
        {
            string enhancedDescription = description.ScrubForOpenApi();

            if (!isDeprecated)
            {
                return enhancedDescription;
            }

            string deprecationSegment = $"{string.Join(" ", deprecationReasons ?? new string[0])} {enhancedDescription}".Trim();

            enhancedDescription = "Deprecated";

            if (!string.IsNullOrWhiteSpace(deprecationSegment))
            {
                enhancedDescription += $": {deprecationSegment}";
            }

            return enhancedDescription;
        }

        public static string ScrubForOpenApi(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            // Remove characters that break Open API presentation (anything outside of {space} through {tilde})
            return
                Regex.Replace(text, @"[^ -~]", " ");
        }
    }
}
