// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EdFi.Ods.Api.Common.Validation;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Extensions;
using FluentValidation;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    public class FluentValidationPutPostRequestResourceValidator : ObjectValidatorBase, IResourceValidator
    {
        private static readonly ConcurrentDictionary<Type, IValidator> ValidatorByType
            = new ConcurrentDictionary<Type, IValidator>();

        public ICollection<ValidationResult> ValidateObject(object resource)
        {
            Type objectType = resource.GetType();

            // Only handle PUT and POST request objects
            // TODO: Embedded convention - request class names, and namespace
            if (!objectType.Name.EndsWith("Put")
                && !objectType.Name.EndsWith("Post")
                || !objectType.FullName.Contains(".Requests."))
            {
                // No validation to be performed
                return new List<ValidationResult>();
            }

            var validator = ValidatorByType.GetOrAdd(
                objectType,
                t =>
                {
                    // Locate the validator by convention
                    string typeName;

                    if (!objectType.Name.TryTrimSuffix("Put", out typeName)
                        && !objectType.Name.TryTrimSuffix("Post", out typeName))
                    {
                        throw new NotSupportedException(
                            string.Format(
                                "Only Put and Post request objects are supported by the '{0}'.",
                                typeof(FluentValidationPutPostRequestResourceValidator).Name));
                    }

                    // Assumption: Request classes are assumed to be derived directly from resource classes, 
                    // and the validator is generated with that class.
                    // TODO: Embedded convention (FluentValidator namespace and naming conventions used for Put/Post validation)
                    string validatorTypeName = string.Format(
                        "{0}, {1}",
                        objectType.BaseType.FullName + "PutPostRequestValidator",
                        objectType.BaseType.Assembly.GetName()
                                  .FullName);

                    var validatorType = Type.GetType(validatorTypeName, throwOnError: false);

                    if (validatorType == null)
                    {
                        return null;
                    }

                    return (IValidator) Activator.CreateInstance(validatorType);
                });

            if (validator == null)
            {
                return new List<ValidationResult>();
            }

            var result = validator.Validate(resource);

            var validationResults = result.Errors
                .Select( e => e.ErrorMessage)
                .Distinct()
                .Select(msg => new ValidationResult(msg))
                .ToList();

            return validationResults;
        }
    }
}
