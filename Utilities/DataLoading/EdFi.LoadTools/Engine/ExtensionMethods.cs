// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EdFi.LoadTools.Engine
{
    public static class ExtensionMethods
    {
        public static string InitialUpperCase(this string text)
        {
            return text.Substring(0, 1).ToUpperInvariant() + text.Substring(1);
        }

        public static bool AreMatchingSimpleTypes(string jsonType, string xmlType)
        {
            return string.Compare(jsonType, xmlType, StringComparison.OrdinalIgnoreCase) == 0
                   || Constants.AtomicTypes.Any(x => x.Json == jsonType && x.Xml == xmlType);
        }

        public static bool AreMatchingDateTypes(string jsonType, string xmlType)
        {
            return !string.IsNullOrEmpty(jsonType)
                   && (jsonType.Equals(Constants.JsonTypes.DateTime) || jsonType.Equals(Constants.JsonTypes.Date))
                   && (string.Compare(jsonType, xmlType, StringComparison.OrdinalIgnoreCase) == 0 ||
                       Constants.AtomicTypes.Any(x => x.Json == jsonType && x.Xml == xmlType));
        }

        public static bool AreMatchingSimpleTypes(Type type1, Type type2)
        {
            return type1 == type2
                   || GetUnderlyingType(type1) == GetUnderlyingType(type2);
        }

        public static Type GetUnderlyingType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                ? Nullable.GetUnderlyingType(type)
                : type;
        }

        public static bool IsPrimitiveType(this Type t)
        {
            return t.IsPrimitive || t.IsValueType || t == typeof(string);
        }

        /// <summary>
        ///     This extension method implements a string comparison algorithm
        ///     based on character pair similarity "shingling"
        ///     Source: http://www.hpl.hp.com/techreports/Compaq-DEC/SRC-TN-1997-015.pdf
        /// </summary>
        public static double PercentMatchTo(this string str1, string str2)
        {
            var pairs1 = WordLetterPairs(str1.InitialUpperCase());
            var pairs2 = WordLetterPairs(str2.InitialUpperCase());

            var intersection = 0;
            var union = pairs1.Count + pairs2.Count;

            foreach (var t in pairs1)
            {
                for (var j = 0; j < pairs2.Count; j++)
                {
                    if (t != pairs2[j])
                    {
                        continue;
                    }

                    intersection++;

                    pairs2.RemoveAt(
                        j); //Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success

                    break;
                }
            }

            // always return something more than zero
            return Math.Max(2.0 * intersection / union, 0.000001D);
        }

        /// <summary>
        ///     Gets all letter pairs for each
        ///     individual word in the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static List<string> WordLetterPairs(string str)
        {
            var allPairs = new List<string>();

            // Tokenize the string and put the tokens/words into an array
            var words = Regex.Split(str, @"[\s/]");

            // For each word
            foreach (var pairsInWord in from t in words
                                        where !string.IsNullOrEmpty(t)
                                        select LetterPairs(t))
            {
                allPairs.AddRange(pairsInWord);
            }

            return allPairs;
        }

        /// <summary>
        ///     Generates an array containing every
        ///     two consecutive letters in the input string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static IEnumerable<string> LetterPairs(string str)
        {
            var numPairs = str.Length - 1;
            var pairs = new string[numPairs];

            for (var i = 0; i < numPairs; i++)
            {
                pairs[i] = str.Substring(i, 2);
            }

            return pairs;
        }

        public static double PropertyPathPercentMatchTo(string xmlPath, string jsonPath)
        {
            var xmlPathSegments = xmlPath.Split('/').ToList();
            var jsonSegments = jsonPath.Split('/').ToList();

            return xmlPath.PercentMatchTo(jsonPath)
                   + xmlPathSegments.FirstOrDefault()
                                    .PercentMatchTo(jsonSegments.FirstOrDefault())
                   + xmlPathSegments.LastOrDefault()
                                    .PercentMatchTo(jsonSegments.LastOrDefault());
        }
    }
}
