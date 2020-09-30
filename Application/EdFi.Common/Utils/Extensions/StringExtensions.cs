// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Common.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool AsOptionalBool(this string s)
        {
            bool value;
            return bool.TryParse(s, out value) && value;
        }

        public static string ReplaceLastOccurrence(this string s, string find, string replace)
        {
            if (!s.Contains(find))
            {
                return s;
            }

            int Place = s.LastIndexOf(find, StringComparison.Ordinal);

            string result = s.Remove(Place, find.Length)
                             .Insert(Place, replace);

            return result;
        }

        public static string JoinWithCharacter(this string baseUri, string path, char joinCharacter)
        {
            baseUri = baseUri.TrimEnd(joinCharacter);
            path = path.TrimStart(joinCharacter);
            return baseUri + joinCharacter + path;
        }
    }
}
