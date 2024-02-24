// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation;
using FluentValidation.Internal;

namespace EdFi.Ods.Common.Validation
{
    /// <summary>
    /// Implements an <see cref="IExplicitObjectValidator"/> that uses the FluentValidation library
    /// to validate objects with explicit rule sets.
    /// </summary>
    public class FluentValidationObjectValidator : IObjectValidator, IExplicitObjectValidator
    {
        private static readonly ICollection<ValidationResult> EmptyValidationResults = new ValidationResult[0];
        private readonly IValidator[] _validators;

        private readonly ConcurrentDictionary<Type, IEnumerable<IValidator>> _validatorsByType
            = new ConcurrentDictionary<Type, IEnumerable<IValidator>>();

        public FluentValidationObjectValidator(IValidator[] validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Validates an object using a specific externally defined rule set.
        /// </summary>
        /// <param name="object">The object to be validated.</param>
        /// <param name="ruleSetName">The name of the externally defined rule set to be executed.</param>
        /// <returns>The results of the validation.</returns>
        public ICollection<ValidationResult> ValidateObject(object @object, string ruleSetName)
        {
            return PerformValidation(
                new ValidationContext<object>(
                    @object,
                    new PropertyChain(),
                    new RulesetValidatorSelector(new List<string> { ruleSetName })));
        }

        /// <summary>
        /// Validates an object.
        /// </summary>
        /// <param name="object">The object obe validated.</param>
        /// <returns>The results of the validation.</returns>
        public ICollection<ValidationResult> ValidateObject(object @object)
        {
            return PerformValidation(
                new ValidationContext<object>(@object));
        }

        private ICollection<ValidationResult> PerformValidation(ValidationContext<object> validationContext)
        {
            // Don't do any processing if there are no FluentValidation validators
            if (_validators == null || _validators.Length == 0)
            {
                return EmptyValidationResults;
            }

            var objectType = validationContext.InstanceToValidate.GetType();

            // Run all registered fluent validators that can validate the specified type using the supplied rule set name
            var fluentValidationResults = GetValidators(objectType)
               .Select(x => x.Validate(validationContext));

            // Combine and adapt the results to DataAnnotation's ValidationResult
            var validationResults = fluentValidationResults
               .SelectMany(x => x.Errors.Select(e => new ValidationResult(e.ErrorMessage)));

            return validationResults.ToList();
        }

        private IEnumerable<IValidator> GetValidators(Type objectType)
        {
            IEnumerable<IValidator> validators;

            if (_validatorsByType.TryGetValue(objectType, out validators))
            {
                return validators;
            }

            validators = _validators
                        .Where(x => x.CanValidateInstancesOfType(objectType))
                        .ToList();

            _validatorsByType.TryAdd(objectType, validators);

            return validators;
        }
    }
}
