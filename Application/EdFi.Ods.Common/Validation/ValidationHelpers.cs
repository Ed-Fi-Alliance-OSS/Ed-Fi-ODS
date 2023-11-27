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

    #region Copied from Validator
    /*
    public static bool TryValidateObject(object instance, ValidationContext validationContext,
        ICollection<ValidationResult>? validationResults, bool validateAllProperties)
    {
        if (instance == null)
        {
            throw new ArgumentNullException(nameof(instance));
        }

        if (validationContext != null && instance != validationContext.ObjectInstance)
        {
            throw new ArgumentException(SR.Validator_InstanceMustMatchValidationContextInstance, nameof(instance));
        }

        var result = true;
        var breakOnFirstError = (validationResults == null);

        foreach (ValidationError err in GetObjectValidationErrors(instance, validationContext!, validateAllProperties, breakOnFirstError))
        {
            result = false;

            validationResults?.Add(err.ValidationResult);
        }

        return result;
    }
    
    private static List<ValidationError> GetObjectValidationErrors(object instance,
        ValidationContext validationContext, bool validateAllProperties, bool breakOnFirstError)
    {
        Debug.Assert(instance != null);

        if (validationContext == null)
        {
            throw new ArgumentNullException(nameof(validationContext));
        }

        // Step 1: Validate the object properties' validation attributes
        var errors = new List<ValidationError>();
        errors.AddRange(GetObjectPropertyValidationErrors(instance, validationContext, validateAllProperties,
            breakOnFirstError));

        // We only proceed to Step 2 if there are no errors
        if (errors.Count > 0)
        {
            return errors;
        }

        // Step 2: Validate the object's validation attributes
        var attributes = _store.GetTypeValidationAttributes(validationContext);
        errors.AddRange(GetValidationErrors(instance, validationContext, attributes, breakOnFirstError));

        // We only proceed to Step 3 if there are no errors
        if (errors.Count > 0)
        {
            return errors;
        }

        // Step 3: Test for IValidatableObject implementation
        if (instance is IValidatableObject validatable)
        {
            var results = validatable.Validate(validationContext);

            if (results != null)
            {
                foreach (ValidationResult result in results)
                {
                    if (result != ValidationResult.Success)
                    {
                        errors.Add(new ValidationError(null, instance, result));
                    }
                }
            }
        }

        return errors;
    }

    private static IEnumerable<ValidationError> GetObjectPropertyValidationErrors(object instance,
        ValidationContext validationContext, bool validateAllProperties, bool breakOnFirstError)
    {
        var properties = GetPropertyValues(instance, validationContext);
        var errors = new List<ValidationError>();

        foreach (var property in properties)
        {
            // get list of all validation attributes for this property
            var attributes = _store.GetPropertyValidationAttributes(property.Key);

            if (validateAllProperties)
            {
                // validate all validation attributes on this property
                errors.AddRange(GetValidationErrors(property.Value, property.Key, attributes, breakOnFirstError));
            }
            else
            {
                // only validate the first Required attribute
                foreach (ValidationAttribute attribute in attributes)
                {
                    if (attribute is RequiredAttribute reqAttr)
                    {
                        // Note: we let the [Required] attribute do its own null testing,
                        // since the user may have subclassed it and have a deeper meaning to what 'required' means
                        var validationResult = reqAttr.GetValidationResult(property.Value, property.Key);
                        if (validationResult != ValidationResult.Success)
                        {
                            errors.Add(new ValidationError(reqAttr, property.Value, validationResult!));
                        }
                        break;
                    }
                }
            }

            if (breakOnFirstError && errors.Count > 0)
            {
                break;
            }
        }

        return errors;
    }

    private sealed class ValidationError
    {
        private readonly object? _value;
        private readonly ValidationAttribute? _validationAttribute;

        internal ValidationError(ValidationAttribute? validationAttribute, object? value,
            ValidationResult validationResult)
        {
            _validationAttribute = validationAttribute;
            ValidationResult = validationResult;
            _value = value;
        }

        internal ValidationResult ValidationResult { get; }

        internal void ThrowValidationException() => throw new ValidationException(ValidationResult, _validationAttribute, _value);
    }
    */
    #endregion
    
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
