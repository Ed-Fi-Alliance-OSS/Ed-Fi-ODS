// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Database.NamingConventions;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.ChangeQueries.Repositories;

public static class TrackedChangesSelectColumnHelpers
{
    private static readonly Regex TermSplitterRegex = new("([A-Z][^A-Z]+|[A-Z]+(?![^A-Z]))", RegexOptions.Compiled);

    public static IEnumerable<SelectColumn> GetSelectColumnsForSurrogateIdentifierUsage(
        string entityPropertyName,
        IEnumerable<string> naturalIdentifyingPropertyNames,
        IDatabaseNamingConvention namingConvention)
    {
        var allTerms = SplitTerms(entityPropertyName);
        var baseTerms = TrimFinalTerm(allTerms);

        foreach (var naturalIdentifyingPropertyName in naturalIdentifyingPropertyNames)
        {
            var naturalTerms = SplitTerms(naturalIdentifyingPropertyName);

            var changeQueryColumnName = 
                string.Join(string.Empty, baseTerms.Concat(naturalTerms.SkipWhile(t => t == baseTerms[^1])));

            yield return new SelectColumn
            {
                ColumnGroup = ColumnGroups.OldValue,
                ColumnName = namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.OldKeyValueColumnPrefix}{changeQueryColumnName}"),
                JsonPropertyName = changeQueryColumnName.ToCamelCase(),
            };

            yield return new SelectColumn
            {
                ColumnGroup = ColumnGroups.NewValue,
                ColumnName = namingConvention.ColumnName($"{ChangeQueriesDatabaseConstants.NewKeyValueColumnPrefix}{changeQueryColumnName}"),
                JsonPropertyName = changeQueryColumnName.ToCamelCase(),
            };
        }

        yield break;
                    
        string[] SplitTerms(string text) => TermSplitterRegex.Matches(text).SelectMany(m => m.Captures.Select(c => c.Value)).ToArray();
        string[] TrimFinalTerm(string[] terms) => terms.Take(terms.Length - 1).ToArray();
    }
}
