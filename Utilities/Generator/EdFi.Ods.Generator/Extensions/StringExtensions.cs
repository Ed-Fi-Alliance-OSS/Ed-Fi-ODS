// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;
using EdFi.Ods.Generator.Database.NamingConventions;

namespace EdFi.Ods.Generator.Extensions
{
    public static class StringExtensions
    {
        private static readonly SHA256 Hasher = SHA256.Create();
        
        public static string Truncate(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length);
            }

            return text;
        }

        public static string ApplyPrefix(this string text, string prefix)
        {
            // If text is empty/null, or is already prefixed with the supplied prefix, return now
            if (string.IsNullOrEmpty(text) || text.StartsWith(prefix))
            {
                return text;
            }

            return prefix + text;
        }

        public static string ApplyLongNameConvention(this PhysicalNameParts physicalNameParts, bool lowerCaseNames = false, int maxLength = 128)
        {
            if (string.IsNullOrEmpty(physicalNameParts?.Name))
            {
                return null;
            }
            
            string rawName = physicalNameParts.ToString();
            
            if (rawName.Length <= maxLength)
            {
                return lowerCaseNames ? rawName.ToLower() : rawName;
            }

            return FinalNameByArgs.GetOrAdd(
                (rawName, lowerCaseNames, maxLength),
                tuple =>
                {
                    var (rn, toLower, length) = tuple;
                    
                    var truncatedHash = GetTruncatedHash(physicalNameParts.Name);

                    var hashPart =
                        $"_{truncatedHash}{(string.IsNullOrEmpty(physicalNameParts.Suffix) || physicalNameParts.Suffix.StartsWith("_") ? string.Empty : "_")}";

                    int shortenedNameLength = maxLength
                        - (physicalNameParts.Prefix?.Length ?? 0)
                        - (physicalNameParts.Suffix?.Length ?? 0)
                        - hashPart.Length;

                    var shortenedNamePart = physicalNameParts.Name.Substring(0, shortenedNameLength);

                    var finalName = $"{physicalNameParts.Prefix}{shortenedNamePart}{hashPart}{physicalNameParts.Suffix}";
                    
                    return toLower ? finalName.ToLower() : finalName;
                });
        }

        public static string GetTruncatedHash(this string text)
        {
            var hash = Hasher.ComputeHash(Encoding.UTF8.GetBytes(text));

            var truncatedHash = BitConverter.ToString(hash).Replace("-", string.Empty).Substring(0, 6).ToLower();

            return truncatedHash;
        }

        private static readonly ConcurrentDictionary<(string, bool, int), string> FinalNameByArgs =
            new ConcurrentDictionary<(string, bool, int), string>();
        
        public static bool TryTrimSuffix(this string text, string suffix, out string trimmedText)
        {
            trimmedText = null;

            if (text == null)
            {
                return false;
            }

            int pos = text.LastIndexOf(suffix);

            if (pos < 0)
            {
                return false;
            }

            if (text.Length - pos == suffix.Length)
            {
                trimmedText = text.Substring(0, pos);
                return true;
            }

            ;

            return false;
        }

        public static string TrimSuffix(this string text, string suffix)
        {
            string trimmedText;

            if (TryTrimSuffix(text, suffix, out trimmedText))
            {
                return trimmedText;
            }

            return text;
        }
    }
}
