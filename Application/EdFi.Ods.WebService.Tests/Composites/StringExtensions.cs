// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;

namespace EdFi.Ods.WebService.Tests.Composites
{
    public static class StringExtensions
    {
        public static List<string> ParseNamesFromCsvText(this string csvText)
        {
            return
                csvText.Split(
                            new[]
                            {
                                ','
                            },
                            StringSplitOptions.RemoveEmptyEntries)
                       .Select(x => x.Trim())
                       .ToList();
        }

        public static string EnsureIsJsonArray(this string content, out bool convertedToArray)
        {
            // Convert single object results into an array for testing purposes
            if (content.StartsWith("{"))
            {
                convertedToArray = true;
                return "[" + content + "]";
            }

            convertedToArray = false;
            return content;
        }
    }
}
