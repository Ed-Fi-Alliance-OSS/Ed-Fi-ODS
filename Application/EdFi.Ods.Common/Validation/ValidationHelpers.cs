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
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models;

namespace EdFi.Ods.Common.Validation;

public static class ValidationHelpers
{
    public const string JsonPathSeparator = ".";

    public const string StringLengthWithMinimumMessageFormat = "{0} must be between {2} and {1} characters in length.";
    public const string StringLengthMessageFormat = "{0} must be at most {1} characters in length.";

    public const string RangeMessageFormat = "{0} must be between {1} and {2}.";
    public const string RangeMinOnlyMessageFormat = "{0} must be greater than or equal to {1}.";
    public const string RangeMaxOnlyMessageFormat = "{0} must be less than or equal to {2}.";

    public const string RequiredObjectMessageFormat = "{0} is required.";
    
    private static readonly List<string> _collectionIndexer = new();

    public static StringBuilder GetPathBuilder(ValidationContext validationContext)
    {
        var contextItems = validationContext.Items;

        StringBuilder pathBuilder;

        if (contextItems.TryGetValue(ValidationContextKeys.PathBuilder, out object pathBuilderAsObject))
        {
            pathBuilder = (StringBuilder) pathBuilderAsObject;
        }
        else
        {
            pathBuilder = new StringBuilder();
            contextItems.Add(ValidationContextKeys.PathBuilder, pathBuilder);
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

            var context = new ValidationContext(item, validationContext, validationContext.Items);
            itemResults ??= new List<ValidationResult>();

            if (!Validator.TryValidateObject(item, context, itemResults, validateAllProperties: true, validateEverything: true))
            {
                string pathPrefix = pathBuilder.ToString();

                foreach (var itemResult in itemResults)
                {
                    string memberName = itemResult.MemberNames.FirstOrDefault();

                    if (memberName?.StartsWith(pathPrefix) == false)
                    {
                        yield return new ValidationResult(itemResult.ErrorMessage, new[] { $"{pathPrefix}.{memberName}" });
                    }
                    else
                    {
                        yield return new ValidationResult(itemResult.ErrorMessage, new[] { memberName });
                    }
                }
                
                itemResults.Clear();
            }

            pathBuilder.Length = originalLength;

            i++;
        }
    }

    public static IEnumerable<ValidationResult> ValidateExtensions(ValidationContext parentValidationContext, IMappingContract mappingContract)
    {
        var pathBuilder = GetPathBuilder(parentValidationContext);

        int originalLength = pathBuilder.Length;

        if (parentValidationContext.ObjectInstance is IHasExtensions parentWithExtensions)
        {
            var extensionsMappingContract = mappingContract as IExtensionsMappingContract;

            foreach (DictionaryEntry entry in parentWithExtensions.Extensions)
            {
                string extensionName = entry.Key as string;
                
                // Skip processing any extensions that aren't supported by the profile, if applicable
                if (!(extensionsMappingContract?.IsExtensionSupported(extensionName) ?? true))
                {
                    continue;
                }

                // If the object is null, throw an exception (this should never happen)
                if (entry.Value == null)
                {
                    throw new NullReferenceException($"The '{extensionName}' extension entry had no object instance to be validated.");
                }

                pathBuilder.Append(JsonPathSeparator);
                pathBuilder.Append(extensionName.ToCamelCase());

                var context = new ValidationContext(
                    entry.Value,
                    parentValidationContext,
                    parentValidationContext.Items.ForExtension(extensionName));

                var itemResults = new List<ValidationResult>();

                if (!Validator.TryValidateObject(entry.Value, context, itemResults, validateAllProperties: true, validateEverything: true))
                {
                    string pathPrefix = pathBuilder.ToString();

                    foreach (var result in itemResults)
                    {
                        string memberName = result.MemberNames.FirstOrDefault();

                        if (memberName?.StartsWith(pathPrefix) == false)
                        {
                            yield return new ValidationResult(result.ErrorMessage, new[] { $"{pathPrefix}.{memberName}" });
                        }
                        else
                        {
                            yield return new ValidationResult(result.ErrorMessage, new[] { memberName });
                        }
                    }
                }

                pathBuilder.Length = originalLength;
            }
        }
    }

    public static IEnumerable<ValidationResult> ValidateEmbeddedObject(ValidationContext validationContext)
    {
        var context = new ValidationContext(validationContext.ObjectInstance, validationContext, validationContext.Items);
        var itemResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(validationContext.ObjectInstance, context, itemResults, validateAllProperties: true, validateEverything: true))
        {
            var pathBuilder = GetPathBuilder(validationContext);

            string pathPrefix = pathBuilder.ToString();

            foreach (var result in itemResults)
            {
                string memberName = result.MemberNames.FirstOrDefault();

                if (memberName?.StartsWith(pathPrefix) == false)
                {
                    yield return new ValidationResult(result.ErrorMessage, new[] { $"{pathPrefix}.{memberName}" });
                }
                else
                {
                    yield return result; //new ValidationResult(result.ErrorMessage, new[] { memberName });
                }
            }
        }
    }
}
