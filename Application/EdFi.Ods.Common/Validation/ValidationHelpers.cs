// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EdFi.Ods.Common.Validation;

public static class ValidationHelpers
{
    public const string JsonPathSeparator = ".";

    public const string StringLengthWithMinimumMessageFormat = "{0} must between {2} and {1} characters in length.";
    public const string StringLengthMessageFormat = "{0} must be at most {1} characters in length.";
    public const string StringLengthMaxOf1MessageFormat = "{0} must be at most {1} character in length.";

    private static readonly List<string> _collectionIndexer = new();

    private static string GetIndexerText(int index)
    {
        if (index >= _collectionIndexer.Count)
        {
            for (int i = _collectionIndexer.Count; i <= index; i++)
            {
                _collectionIndexer.Add($"[{i}]");
            }
        }

        return _collectionIndexer[index];
    }

    public static IEnumerable<ValidationResult> ValidateCollection(ValidationContext validationContext)
    {
        var contextItems = validationContext.Items;

        var pathBuilder = contextItems.Values.Single() as System.Text.StringBuilder;
        int originalLength = pathBuilder.Length;

        // Generic enumerable validation function
        var enumerable = validationContext.ObjectInstance as IEnumerable;

        if (enumerable == null)
        {
            yield break;
        }

        int i = 0;

        List<ValidationResult> itemResults = null;

        foreach (var item in enumerable)
        {
            pathBuilder.Append(GetIndexerText(i));

            var context = new ValidationContext(item, contextItems);
            itemResults ??= new List<ValidationResult>();
            
            Validator.TryValidateObject(item, context, itemResults, true);

            if (itemResults.Any())
            {
                string pathPrefix = pathBuilder.ToString();

                foreach (var itemResult in itemResults)
                {
                    string memberName = itemResult.MemberNames.FirstOrDefault();

                    yield return new ValidationResult(itemResult.ErrorMessage, new[] { $"{pathPrefix}.{memberName}" });
                }
                
                itemResults.Clear();
            }

            pathBuilder.Length = originalLength;

            i++;
        }
    }
    
    public static IEnumerable<ValidationResult> ValidateExtensions(ValidationContext validationContext)
    {
        var contextItems = validationContext.Items;

        var pathBuilder = (StringBuilder) contextItems.Values.First();
        int originalLength = pathBuilder.Length;

        if (validationContext.ObjectInstance is IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                pathBuilder.Append(JsonPathSeparator);
                pathBuilder.Append(entry.Key);

                var context = new ValidationContext(entry.Value, contextItems);
                var itemResults = new List<ValidationResult>();
                Validator.TryValidateObject(entry.Value, context, itemResults, validateAllProperties: true);

                if (itemResults.Any())
                {
                    foreach (var result in itemResults) yield return result;
                }

                pathBuilder.Length = originalLength;
            }
        }
    }
}
