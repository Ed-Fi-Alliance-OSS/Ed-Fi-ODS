// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace EdFi.Ods.Common.Extensions
{
    public static class ExplicitObjectValidatorExtensions
    {
        /// <summary>
        /// Validates an object using multiple validators with an explicit rule set and aggregates the results.
        /// </summary>
        /// <param name="validators">The validators to be used to validate the object.</param>
        /// <param name="object">The object to be validated.</param>
        /// <param name="ruleSetName">The name of the rule set to be used.</param>
        /// <returns>The validation results.</returns>
        public static ICollection<ValidationResult> ValidateObject(
            this IEnumerable<IExplicitObjectValidator> validators,
            object @object,
            string ruleSetName)
        {
            var result = new List<ValidationResult>();

            if (validators != null)
            {
                foreach (var validator in validators)
                {
                    try
                    {
                        result.AddRange(validator.ValidateObject(@object, ruleSetName));
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Validation exception [{0}]: {1}", ex.GetType(), ex.StackTrace);
                        result.Add(new ValidationResult(ex.Message));
                    }
                }
            }

            return result;
        }
    }
}
