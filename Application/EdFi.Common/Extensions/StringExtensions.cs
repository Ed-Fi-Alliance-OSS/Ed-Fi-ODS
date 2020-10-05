// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EdFi.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex _termSplitter = new Regex("([A-Z]([A-Z]*)(?=[A-Z])|[A-Z][a-z0-9]+)", RegexOptions.Compiled);

        /// <summary>
        /// Returns a string that is converted to camel casing, detecting and handling acronyms as prefixes and suffixes.
        /// </summary>
        /// <param name="text">The text to be processed.</param>
        /// <returns>A string that has the first character converted to lower-case.</returns>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            if (text.Length == 1)
            {
                return text.ToLower();
            }

            int leadingUpperCharsLength = text.TakeWhile(char.IsUpper)
                                              .Count();

            int prefixLength = leadingUpperCharsLength - 1;

            if (text.Length == leadingUpperCharsLength

                // Handles the case of an acronym with a trailing "s" (e.g. "URIs" -> "uris" not "urIs")
                || text.Length == leadingUpperCharsLength + 1 && text.EndsWith("s"))
            {
                // Convert entire name to lower case
                return text.ToLower();
            }

            if (prefixLength > 0)
            {
                // Apply lower casing to leading acronym
                return text.Substring(0, prefixLength)
                           .ToLower()
                       + text.Substring(prefixLength);
            }

            // Apply simple camel casing
            return char.ToLower(text[0]) + text.Substring(1);
        }

        /// <summary>
        /// Returns a string that has the first character converted to upper-case.
        /// </summary>
        /// <param name="text">The text to be processed.</param>
        /// <returns>A string that has the first character converted to upper-case.</returns>
        public static string ToMixedCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length == 1)
            {
                return text;
            }

            return char.ToUpper(text[0]) + text.Substring(1);
        }

        public static string[] SplitCamelCase(this string text)
        {
            return Regex.Replace(text, "([A-Z])", " $1", RegexOptions.Compiled)
                        .Trim()
                        .Split(' ');
        }

        /// <summary>
        /// Breaks the supplied text into individual words using mixed-casing conventions augmented by delimiters.
        /// </summary>
        /// <param name="compositeTerm">The text to process for display.</param>
        /// <param name="delimiters">Additional delimiters to use as word breaks.</param>
        /// <returns>The text processed for display.</returns>
        public static string NormalizeCompositeTermForDisplay(this string compositeTerm, params char[] delimiters)
        {
            string delimiterExpression = delimiters.Length == 0
                ? string.Empty
                : "(?=[" + string.Join(string.Empty, delimiters.Select(c => @"\" + c)) + "])?";

            var parts = Regex.Matches(
                compositeTerm,
                string.Format(
                    @"((?:[a-z]+|[A-Z]+)(?:[a-z0-9]+)?{0})",
                    delimiters.Length == 0
                        ? string.Empty
                        : delimiterExpression));

            string displayText = string.Empty;

            foreach (Match part in parts)
            {
                displayText += part.Value.ToMixedCase() + " ";
            }

            return displayText.TrimEnd(' ');
        }

        /// <summary>
        /// Returns a string wrapped with single quotes.
        /// </summary>
        /// <param name="text">The text to be wrapped.</param>
        /// <returns>A string wrapped in single quotes.</returns>
        public static string SingleQuoted(this string text)
        {
            return $"'{text}'";
        }

        /// <summary>
        /// Returns a string wrapped with double quotes.
        /// </summary>
        /// <param name="text">The text to be wrapped.</param>
        /// <returns>A string wrapped in double quotes.</returns>
        public static string DoubleQuoted(this string text)
        {
            return $"\"{text}\"";
        }

        public static string Parenthesize(this string text)
        {
            return "(" + text + ")";
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

        public static bool TryReplaceSuffix(this string text, string oldSuffix, string newSuffix, out string newText)
        {
            newText = null;

            string trimmedText;

            if (!text.TryTrimSuffix(oldSuffix, out trimmedText))
            {
                return false;
            }

            newText = trimmedText + newSuffix;
            return true;
        }

        public static string ReplaceSuffix(this string text, string oldSuffix, string newSuffix)
        {
            string newText;

            if (!text.TryReplaceSuffix(oldSuffix, newSuffix, out newText))
            {
                return text;
            }

            return newText;
        }

        public static string EnsureSuffixApplied(this string text, string suffix)
        {
            if (text.EndsWith(suffix))
            {
                return text;
            }

            return text + suffix;
        }

        public static bool TryTrimPrefix(this string text, string prefix, out string trimmedText)
        {
            trimmedText = null;

            if (text == null)
            {
                return false;
            }

            if (text.StartsWith(prefix))
            {
                if (text.Length == prefix.Length)
                {
                    trimmedText = string.Empty;
                }
                else
                {
                    trimmedText = text.Substring(prefix.Length);
                }

                return true;
            }

            return false;
        }

        public static string TrimPrefix(this string text, string prefix)
        {
            string trimmedText;

            if (TryTrimPrefix(text, prefix, out trimmedText))
            {
                return trimmedText;
            }

            return text;
        }

        /// <summary>
        /// Provides an extension-based overload method for performing case-insensitive equality checks more succinctly.
        /// </summary>
        /// <param name="text">The string to be evaluated.</param>
        /// <param name="compareText">The string to compare against.</param>
        /// <returns><b>true</b> if the strings are equal (ignoring case); otherwise <b>false</b>.</returns>
        public static bool EqualsIgnoreCase(this string text, string compareText)
        {
            if (text == null)
            {
                return compareText == null;
            }

            return text.Equals(compareText, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string text, string compareText)
        {
            if (text == null)
            {
                return compareText == null;
            }

            return text.StartsWith(compareText, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool EndsWithIgnoreCase(this string text, string compareText)
        {
            if (text == null)
            {
                return compareText == null;
            }

            return text.EndsWith(compareText, StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool ContainsIgnoreCase(this string text, string compareText)
        {
            if (text == null || compareText == null)
            {
                return false;
            }

            return text.IndexOf(compareText, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        public static bool IsFormatString(this string text)
        {
            return text != null && text.Contains("{0}");
        }

        /// <summary>
        /// Returns an enumerable of string values containing possible identifier values representing
        /// the "core" identifier, trimming one term prefix from the identifier until no terms remain.
        /// </summary>
        /// <param name="possiblyRoleNamedIdentifier"></param>
        /// <returns><see cref="IEnumerable{String}" /></returns>
        public static IEnumerable<string> EnumeratePossibleCoreIdentifiers(
            this string possiblyRoleNamedIdentifier)
        {
            //The properties often have names like "objectiveGradeLevelDescriptor".  So go in a loop, and if you can't find it, trim the first letter off and try again.
            string currentIdentifier = possiblyRoleNamedIdentifier;

            string[] parts = null;
            int partIndex = 0;

            while (true)
            {
                // On first failure to locate due to application of role name, split the term into parts
                if (parts == null)
                {
                    var matches = _termSplitter.Matches(currentIdentifier);

                    parts = matches.Cast<Match>()
                        .Select(m => m.Value)
                        .ToArray();
                }

                if (partIndex >= parts.Length)
                {
                    break;
                }

                // Trim the first word off the model name, and try again
                currentIdentifier = string.Join(string.Empty, parts.Skip(partIndex++));

                if (partIndex == parts.Length && currentIdentifier.Equals("Type"))
                {
                    break;
                }

                yield return currentIdentifier;
            }
        }

        public static string MakeSafeForCSharpClass(this string propertyName, string className)
        {
            return propertyName + (propertyName == className
                       ? "X"
                       : string.Empty);
        }

        /// <summary>
        /// Converts the supplied string value to a boolean, returning the default value (false) if
        /// the value cannot be parsed.
        /// </summary>
        /// <param name="value">The string value to be parsed to a boolean value.</param>
        /// <returns>The parsed boolean value if parseable; otherwise false.</returns>
        public static bool ToBoolean(this string value)
        {
            if (bool.TryParse(value, out bool boolValue))
            {
                return boolValue;
            }

            return default(bool);
        }
    }
}
