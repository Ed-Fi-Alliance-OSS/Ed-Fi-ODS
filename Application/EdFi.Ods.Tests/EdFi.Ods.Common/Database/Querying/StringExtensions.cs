// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Text.RegularExpressions;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Database.Querying
{
    public static class StringExtensions
    {
        public static string NormalizeSql(this string sourceSql)
        {
            return Regex.Replace(sourceSql.Replace('\t', ' '), "\\s+", " ", RegexOptions.Multiline)
                .Replace("( ", "(")
                .Replace(" )", ")")
                .Replace(" ,", ",")
                .Trim();
        }
    }
}
