// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace EdFi.Common.Inflection
{
    // Done: GKM - Unify this with the instance in EdFi.Ods.CodeGen.
    // In the meantime, duplicate any changes made to this file in the corresponding class.

    /*
     * SubSonic - http://subsonicproject.com
     *
     * The contents of this file are subject to the New BSD
     * License (the "License"); you may not use this file
     * except in compliance with the License. You may obtain a copy of
     * the License at http://www.opensource.org/licenses/bsd-license.php
     *
     * Software distributed under the License is distributed on an
     * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
     * implied. See the License for the specific language governing
     * rights and limitations under the License.
    */

    /// <summary>
    ///     Summary for the Inflector class
    /// </summary>
    public static class Inflector
    {
        private static readonly List<InflectorRule> _plurals = new List<InflectorRule>();
        private static readonly List<InflectorRule> _singulars = new List<InflectorRule>();
        private static readonly List<string> _uncountables = new List<string>();

        /// <summary>
        ///     Initializes the <see cref="Inflector" /> class.
        /// </summary>
        static Inflector()
        {
            AddPluralRule("$", "s");
            AddPluralRule("s$", "s");
            AddPluralRule("(ax|test)is$", "$1es");
            AddPluralRule("(octop|vir)us$", "$1i");
            AddPluralRule("(alias|status)$", "$1es");
            AddPluralRule("(bu)s$", "$1ses");
            AddPluralRule("(buffal|tomat)o$", "$1oes");
            AddPluralRule("([ti])um$", "$1a");
            AddPluralRule("sis$", "ses");
            AddPluralRule("(?:([^f])fe|([lr])f)$", "$1$2ves");
            AddPluralRule("(hive)$", "$1s");
            AddPluralRule("([^aeiouy]|qu)y$", "$1ies");
            AddPluralRule("(x|ch|ss|sh)$", "$1es");
            AddPluralRule("(matr|vert|ind)ix|ex$", "$1ices");
            AddPluralRule("([m|l])ouse$", "$1ice");
            AddPluralRule("^(ox)$", "$1en");
            AddPluralRule("(quiz)$", "$1zes");

            AddSingularRule("s$", string.Empty);
            AddSingularRule("ss$", "ss");
            AddSingularRule("(n)ews$", "$1ews");

            // GKM - Removed to prevent Metadata -> Metadatum ----> AddSingularRule("([ti])a$", "$1um");
            AddSingularRule("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis");

            // QSM - Adding this line so that the trailing 's' is not stripped off the already singular form of these words
            AddSingularRule("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)sis$", "$1$2sis");
            AddSingularRule("(^analy)ses$", "$1sis");
            AddSingularRule("([^f])ves$", "$1fe");
            AddSingularRule("(hive)s$", "$1");
            AddSingularRule("(tive)s$", "$1");
            AddSingularRule("([lr])ves$", "$1f");
            AddSingularRule("([^aeiouy]|qu)ies$", "$1y");
            AddSingularRule("(s)eries$", "$1eries");
            AddSingularRule("(m)ovies$", "$1ovie");
            AddSingularRule("(x|ch|ss|sh)es$", "$1");
            AddSingularRule("([m|l])ice$", "$1ouse");
            AddSingularRule("(bus)es$", "$1");
            AddSingularRule("(o)es$", "$1");
            AddSingularRule("(shoe)s$", "$1");
            AddSingularRule("(cris|ax|test)es$", "$1is");
            AddSingularRule("(octop|vir)i$", "$1us");
            AddSingularRule("(alias|status|credits)$", "$1"); // ADW - Handle Additional Credits
            AddSingularRule("(alias|status)es$", "$1");
            AddSingularRule("^(ox)en", "$1");
            AddSingularRule("(vert|ind)ices$", "$1ex");
            AddSingularRule("(matr)ices$", "$1ix");
            AddSingularRule("(quiz)zes$", "$1");

            AddIrregularRule("person", "people");
            AddIrregularRule("man", "men");
            AddIrregularRule("child", "children");
            AddIrregularRule("sex", "sexes");
            AddIrregularRule("tax", "taxes");
            AddIrregularRule("move", "moves");

            AddUnknownCountRule("equipment");
            AddUnknownCountRule("information");
            AddUnknownCountRule("rice");
            AddUnknownCountRule("money");
            AddUnknownCountRule("species");
            AddUnknownCountRule("series");
            AddUnknownCountRule("fish");
            AddUnknownCountRule("sheep");
        }

        /// <summary>
        ///     Adds the irregular rule.
        /// </summary>
        /// <param name="singular">The singular.</param>
        /// <param name="plural">The plural.</param>
        private static void AddIrregularRule(string singular, string plural)
        {
            AddPluralRule(
                string.Concat("(", singular[0], ")", singular.Substring(1), "$"),
                string.Concat("$1", plural.Substring(1)));

            AddSingularRule(
                string.Concat("(", plural[0], ")", plural.Substring(1), "$"),
                string.Concat("$1", singular.Substring(1)));
        }

        /// <summary>
        ///     Adds the unknown count rule.
        /// </summary>
        /// <param name="word">The word.</param>
        private static void AddUnknownCountRule(string word)
        {
            _uncountables.Add(word.ToLower());
        }

        /// <summary>
        ///     Adds the plural rule.
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <param name="replacement">The replacement.</param>
        private static void AddPluralRule(string rule, string replacement)
        {
            _plurals.Add(new InflectorRule(rule, replacement));
        }

        /// <summary>
        ///     Adds the singular rule.
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <param name="replacement">The replacement.</param>
        private static void AddSingularRule(string rule, string replacement)
        {
            _singulars.Add(new InflectorRule(rule, replacement));
        }

        /// <summary>
        ///     Makes the plural.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string MakePlural(string word)
        {
            return ApplyRules(_plurals, word);
        }

        /// <summary>
        ///     Makes the singular.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string MakeSingular(string word)
        {
            return ApplyRules(_singulars, word);
        }

        /// <summary>
        /// Gets the singularized or pluralized form of the supplied word based on the basic count provided.
        /// </summary>
        /// <param name="word">The word to be inflected.</param>
        /// <param name="basisCount">The basis for determining whether to singularize or pluralize the word.</param>
        /// <param name="singularWordOverride">An override value to use for the singular form.</param>
        /// <param name="pluralWordOverride">An override value to use for the plural form.</param>
        /// <returns>The inflected word.</returns>
        public static string Inflect(string word, int basisCount, string singularWordOverride = null, string pluralWordOverride = null)
        {
            if (basisCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(basisCount), "Value must be greater than or equal to 0.");
            }
            
            if (basisCount == 1)
            {
                return singularWordOverride ?? MakeSingular(word);
            }

            return pluralWordOverride ?? MakePlural(word);
        }
        
        /// <summary>
        ///     Applies the rules.
        /// </summary>
        /// <param name="rules">The rules.</param>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        private static string ApplyRules(IList<InflectorRule> rules, string word)
        {
            string result = word;

            if (!_uncountables.Contains(word.ToLower()))
            {
                for (int i = rules.Count - 1; i >= 0; i--)
                {
                    string currentPass = rules[i]
                        .Apply(word);

                    if (currentPass != null)
                    {
                        result = currentPass;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Converts the string to title case.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string ToTitleCase(string word)
        {
            return Regex.Replace(
                ToHumanCase(AddUnderscores(word)),
                @"\b([a-z])",
                delegate(Match match)
                {
                    return match.Captures[0]
                        .Value.ToUpper();
                });
        }

        /// <summary>
        ///     Converts the string to human case.
        /// </summary>
        /// <param name="lowercaseAndUnderscoredWord">The lowercase and underscored word.</param>
        /// <returns></returns>
        public static string ToHumanCase(string lowercaseAndUnderscoredWord)
        {
            return MakeInitialCaps(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
        }

        /// <summary>
        ///     Adds the underscores.
        /// </summary>
        /// <param name="pascalCasedWord">The pascal cased word.</param>
        /// <returns></returns>
        public static string AddUnderscores(string pascalCasedWord)
        {
            return Regex.Replace(
                    Regex.Replace(Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])", "$1_$2"),
                    @"[-\s]",
                    "_")
                .ToLower();
        }

        /// <summary>
        ///     Makes the initial caps.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string MakeInitialCaps(string word)
        {
            return MakeInitialUpperCase(word)
                .ToLower();
        }

        /// <summary>
        ///     Makes the initial lower case.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string MakeInitialLowerCase(string word)
        {
            return string.Concat(
                word.Substring(0, 1)
                    .ToLower(),
                word.Substring(1));
        }

        /// <summary>
        ///     Change the first letter of a string to be upper case without effecting the rest of the string
        /// </summary>
        /// <example>theWord => TheWord</example>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string MakeInitialUpperCase(string word)
        {
            return string.Concat(
                word.Substring(0, 1)
                    .ToUpper(),
                word.Substring(1));
        }

        /// <summary>
        /// Strips the terms to the left.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<string> StripLeftTerms(string name)
        {
            var splitTerms = SplitCamelCase(MakeInitialUpperCase(name));

            for (var idx = 1; idx < splitTerms.Length; idx++)
            {
                yield return splitTerms.Skip(idx)
                    .Aggregate((s1, s2) => s1 + s2);
            }
        }

        /// <summary>
        ///     Join terms, eliminating the duplicates as they are combined
        /// </summary>
        /// <example>AlphaBravoCharlie + BravoCharlieDelta => AlphaBravoCharlieDelta</example>
        /// <param name="nameStrings">some camel-cased terms</param>
        /// <returns></returns>
        public static string CollapseNames(params string[] nameStrings)
        {
            var splitTerms = nameStrings.Select(SplitCamelCase)
                .ToArray();

            var result = splitTerms.Aggregate(OverlapArrays);
            return string.Join(string.Empty, result);
        }

        /// <summary>
        ///     Determine whether the passed string is numeric, by attempting to parse it to a double
        /// </summary>
        /// <param name="str">The string to evaluated for numeric conversion</param>
        /// <returns>
        ///     <c>true</c> if the string can be converted to a number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsStringNumeric(string str)
        {
            double result;
            return double.TryParse(str, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out result);
        }

        /// <summary>
        ///     Adds the ordinal suffix.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string AddOrdinalSuffix(string number)
        {
            if (IsStringNumeric(number))
            {
                int n = int.Parse(number);
                int nMod100 = n % 100;

                if (nMod100 >= 11 && nMod100 <= 13)
                {
                    return string.Concat(number, "th");
                }

                switch (n % 10)
                {
                    case 1:
                        return string.Concat(number, "st");
                    case 2:
                        return string.Concat(number, "nd");
                    case 3:
                        return string.Concat(number, "rd");
                    default:
                        return string.Concat(number, "th");
                }
            }

            return number;
        }

        /// <summary>
        ///     Converts the underscores to dashes.
        /// </summary>
        /// <param name="underscoredWord">The underscored word.</param>
        /// <returns></returns>
        public static string ConvertUnderscoresToDashes(string underscoredWord)
        {
            return underscoredWord.Replace('_', '-');
        }

        private static string[] SplitCamelCase(string input)
        {
            string whitespaced = Replace(MakeInitialUpperCase(input), "([A-Z])", " $1", RegexOptions.Compiled)
                .Trim();

            return whitespaced.Split(' ');
        }

        private static string[] OverlapArrays(string[] s1, string[] s2)
        {
            var l1 = s1.Length;
            var l2 = s2.Length;
            var max = Math.Min(l1, l2);
            var result = new List<string>(s1);

            for (var idx = max; idx > 0; idx--)
            {
                var t1 = string.Join(
                    string.Empty,
                    s1.Skip(l1 - idx)
                        .Take(idx));

                var t2 = string.Join(string.Empty, s2.Take(idx));

                if (t1 != t2)
                {
                    continue;
                }

                result.AddRange(s2.Skip(idx));
                return result.ToArray();
            }

            result.AddRange(s2);
            return result.ToArray();
        }

        /// <summary>
        ///     Summary for the InflectorRule class
        /// </summary>
        private class InflectorRule
        {
            /// <summary>
            /// </summary>
            public readonly Regex regex;

            /// <summary>
            /// </summary>
            public readonly string replacement;

            /// <summary>
            ///     Initializes a new instance of the <see cref="InflectorRule" /> class.
            /// </summary>
            /// <param name="regexPattern">The regex pattern.</param>
            /// <param name="replacementText">The replacement text.</param>
            public InflectorRule(string regexPattern, string replacementText)
            {
                regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
                replacement = replacementText;
            }

            /// <summary>
            ///     Applies the specified word.
            /// </summary>
            /// <param name="word">The word.</param>
            /// <returns></returns>
            public string Apply(string word)
            {
                if (!regex.IsMatch(word))
                {
                    return null;
                }

                string replace = regex.Replace(word, replacement);

                // GKM removed to prevent IInterventionPrescriptionURI from being pluralized to end with "URIS"
                //if (word == word.ToUpper())
                //    replace = replace.ToUpper();

                return replace;
            }
        }
    }
}
