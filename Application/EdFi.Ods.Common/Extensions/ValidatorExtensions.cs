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
    public static class ObjectValidatorExtensions
    {
        public static ICollection<ValidationResult> ValidateObject(this IEnumerable<IObjectValidator> validators, object @object)
        {
            var result = new List<ValidationResult>();

            if (validators != null)
            {
                foreach (var validator in validators)
                {
                    try
                    {
                        result.AddRange(validator.ValidateObject(@object));
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
