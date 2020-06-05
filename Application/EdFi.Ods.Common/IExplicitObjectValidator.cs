// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines methods for validating objects using an explicitly named rule set.
    /// </summary>
    public interface IExplicitObjectValidator
    {
        /// <summary>
        /// Validates an object using a specific externally defined rule set.
        /// </summary>
        /// <param name="object">The object to be validated.</param>
        /// <param name="ruleSetName">The name of the externally defined rule set to be executed.</param>
        /// <returns>The results of the validation.</returns>
        ICollection<ValidationResult> ValidateObject(object @object, string ruleSetName);
    }
}
