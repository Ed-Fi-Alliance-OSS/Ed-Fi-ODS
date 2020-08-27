// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;

namespace Test.Common
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trims the input string at any of the specified delimiter characters, if found.
        /// </summary>
        /// <param name="input">The string to be trimmed.</param>
        /// <param name="delimiter">The character or characters used to trim the string.</param>
        /// <returns>The trimmed string if a delimiter is found; otherwise the original string.</returns>
        public static string TrimAt(this string input, params char[] delimiter)
        {
            return input.Split(delimiter)[0];
        }

        public static bool IsNumeric(this string text)
        {
            return Regex.IsMatch(text, @"^([0-9]+|[0-9]*\.[0-9]+)$");
        }

        public static bool IsDateTime(this string text)
        {
            DateTime ignored;

            return DateTime.TryParse(text, out ignored);
        }

        public static decimal ToDecimal(this string text)
        {
            try
            {
                return Convert.ToDecimal(text);
            }
            catch (FormatException ex)
            {
                throw new FormatException(string.Format("'{0}' could not be converted to a decimal.", text), ex);
            }
        }

        public static DateTime ToDateTime(this string text)
        {
            return DateTime.Parse(text);
        }
    }
}
