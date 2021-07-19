// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace EdFi.Ods.Generator.Extensions
{
    public static class StringExtensions
    {
        private static SHA256 _hasher = SHA256.Create();
        
        public static string Truncate(this string text, int length)
        {
            if (text.Length > length)
            {
                return text.Substring(0, length);
            }

            return text;
        }

        public static string PrefixWith(this string text, string prefix)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return prefix + text;
        }

        public static string ApplyLongNameConvention(this string rawName, string suffixToPreserve = null, int maxLength = 128)
        {
            if (rawName.Length <= maxLength)
            {
                return rawName;
            }

            var hash = _hasher.ComputeHash(Encoding.UTF8.GetBytes(rawName));
            var hashText = BitConverter.ToString(hash).Replace("-", string.Empty).Substring(0, 6).ToLower();

            if (suffixToPreserve == null)
            {
                return rawName.Substring(0, maxLength - 6) + hashText;
            }

            if (!rawName.EndsWith(suffixToPreserve))
            {
                throw new ArgumentException($"'{rawName}' does not end with supplied suffix '{suffixToPreserve}'.");
            }

            var coreText = rawName.TrimSuffix(suffixToPreserve);

            return coreText.Substring(0, maxLength - suffixToPreserve.Length - 6) + hashText + suffixToPreserve;
        }

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
