// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
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

    public const string RangeMessageFormat = "{0} must be between {1} and {2}.";
    public const string RangeMinOnlyMessageFormat = "{0} must be greater than or equal to {1}.";
    public const string RangeMaxOnlyMessageFormat = "{0} must be less than or equal to {2}.";

    public const string RequiredObjectMessageFormat = "{0} is required.";
    
    private const string PathBuilderKey = "PathBuilder";
    
    private static readonly List<string> _collectionIndexer = new();

    public static StringBuilder GetPathBuilder(ValidationContext validationContext)
    {
        var contextItems = validationContext.Items;

        StringBuilder pathBuilder;

        if (contextItems.TryGetValue(PathBuilderKey, out object pathBuilderAsObject))
        {
            pathBuilder = (StringBuilder) pathBuilderAsObject;
        }
        else
        {
            pathBuilder = new StringBuilder();
            contextItems.Add(PathBuilderKey, pathBuilder);
        }

        return pathBuilder;
    }

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
        var pathBuilder = GetPathBuilder(validationContext);

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

            var context = new ValidationContext(item, validationContext.Items);
            itemResults ??= new List<ValidationResult>();
            
            if (!Validator.TryValidateObject(item, context, itemResults, true))
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
        var pathBuilder = GetPathBuilder(validationContext);

        int originalLength = pathBuilder.Length;

        if (validationContext.ObjectInstance is IDictionary dictionary)
        {
            foreach (DictionaryEntry entry in dictionary)
            {
                pathBuilder.Append(JsonPathSeparator);
                pathBuilder.Append(entry.Key);

                var context = new ValidationContext(entry.Value, validationContext.Items);
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

    public static IEnumerable<ValidationResult> ValidateEmbeddedObject(ValidationContext validationContext)
    {
        var context = new ValidationContext(validationContext.ObjectInstance, validationContext.Items);
        var itemResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(validationContext.ObjectInstance, context, itemResults, true))
        {
            foreach (var result in itemResults) yield return result;
        }
    }
}
