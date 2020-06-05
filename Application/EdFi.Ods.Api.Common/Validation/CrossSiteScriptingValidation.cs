// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Ods.Api.Common.Validation {
    /// <summary>
    /// Microsoft Web Protection Library (AntiXSS) has reached End of Life.
    /// The page states "In .NET 4.0 a version of AntiXSS was included in the framework and could be enabled via configuration. In ASP.NET v5 a white list based encoder will be the only encoder."
    /// note pulled from the deprecated assembly
    /// </summary>
    public static class CrossSiteScriptingValidation
    {
        private static readonly char[] _startingChars =
        {
            '<',
            '&'
        };

        // Only accepts http: and https: protocols, and protocol-less urls.
        // Used by web parts to validate import and editor input on Url properties. 
        // Review: is there a way to escape colon that will still be recognized by IE?
        // %3a does not work with IE.
        public static bool IsDangerousUrl(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            // Trim the string inside this method, since a Url starting with whitespace
            // is not necessarily dangerous.  This saves the caller from having to pre-trim 
            // the argument as well.
            s = s.Trim();

            var len = s.Length;

            if ((len > 4) &&
                ((s[0] == 'h') || (s[0] == 'H')) &&
                ((s[1] == 't') || (s[1] == 'T')) &&
                ((s[2] == 't') || (s[2] == 'T')) &&
                ((s[3] == 'p') || (s[3] == 'P')))
            {
                if ((s[4] == ':') || ((len > 5) && ((s[4] == 's') || (s[4] == 'S')) && (s[5] == ':')))
                {
                    return false;
                }
            }

            var colonPosition = s.IndexOf(':');
            return colonPosition != -1;
        }

        public static bool IsValidJavascriptId(string id)
        {
            return (String.IsNullOrEmpty(id) ||
                    System.CodeDom.Compiler.CodeGenerator.IsValidLanguageIndependentIdentifier(id));
        }

        public static bool IsDangerousString(string s, out int matchIndex)
        {
            //bool inComment = false;
            matchIndex = 0;

            for (var i = 0;;)
            {
                // Look for the start of one of our patterns 
                var n = s.IndexOfAny(_startingChars, i);

                // If not found, the string is safe
                if (n < 0)
                    return false;

                // If it's the last char, it's safe 
                if (n == s.Length - 1)
                    return false;

                matchIndex = n;

                switch (s[n])
                {
                    case '<':
                        // If the < is followed by a letter or '!', it's unsafe (looks like a tag or HTML comment)
                        if (IsAtoZ(s[n + 1]) || s[n + 1] == '!' || s[n + 1] == '/' || s[n + 1] == '?')
                            return true;

                        break;
                    case '&':
                        // If the & is followed by a #, it's unsafe (e.g. S) 
                        if (s[n + 1] == '#')
                            return true;

                        break;
                }

                // Continue searching
                i = n + 1;
            }
        }

        private static bool IsAtoZ(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
