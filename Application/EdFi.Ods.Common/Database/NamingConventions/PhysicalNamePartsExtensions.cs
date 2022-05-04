// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace EdFi.Ods.Common.Database.NamingConventions
{
    public static class PhysicalNamePartsExtensions
    {
        private static readonly SHA256 _hasher = SHA256.Create();
        
        private static readonly ConcurrentDictionary<(string, bool, int), string> _finalNameByArgs =
            new ConcurrentDictionary<(string, bool, int), string>();
        
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

            return _finalNameByArgs.GetOrAdd(
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

        private static string GetTruncatedHash(this string text)
        {
            var hash = _hasher.ComputeHash(Encoding.UTF8.GetBytes(text));

            var truncatedHash = BitConverter.ToString(hash).Replace("-", string.Empty).Substring(0, 6).ToLower();

            return truncatedHash;
        }
    }
}
