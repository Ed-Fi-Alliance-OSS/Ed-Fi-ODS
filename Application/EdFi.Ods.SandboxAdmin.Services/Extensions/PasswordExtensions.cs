// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;

namespace EdFi.Ods.SandboxAdmin.Services.Extensions
{
    public static class PasswordExtensions
    {
        public const string AllowedSymbols = "!,&,*,(,),@,#,$,%,^";
        public const int MinimumLength = 8;

        private const string LowerCase = "a-z";
        private const string UpperCase = "A-Z";
        private const string Digits = "0-9";

        private static string Pattern
        {
            get
            {
                return string.Format(
                    "^[{0},{1},{2},{3}]*$",
                    LowerCase,
                    UpperCase,
                    Digits,
                    AllowedSymbols);
            }
        }

        public static bool IsStrongPassword(this string password)
        {
            return password.Length >= MinimumLength
                   && HasCharacter(password, Digits)
                   && HasCharacter(password, LowerCase)
                   && HasCharacter(password, UpperCase)
                   && HasCharacter(password, AllowedSymbols)
                   && Regex.IsMatch(password, Pattern);
        }

        private static bool HasCharacter(string input, string pattern)
        {
            return Regex.IsMatch(input, string.Format("^.*[{0}].*$", pattern));
        }
    }
}