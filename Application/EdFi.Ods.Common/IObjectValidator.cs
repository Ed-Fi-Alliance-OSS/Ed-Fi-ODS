// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common
{
    /// <summary>
    /// Defines a method for validating an object.
    /// </summary>
    public interface IObjectValidator
    {
        /// <summary>
        /// Validates an object.
        /// </summary>
        /// <param name="object">The object to be validated.</param>
        /// <returns>The validation results.</returns>
        ICollection<ValidationResult> ValidateObject(object @object);
    }

    /// <summary>
    /// Provides a strongly typed interface specifically for validating persistent entities.
    /// </summary>
    public interface IEntityValidator : IObjectValidator { }

    /// <summary>
    /// Provides a strongly typed interface specifically for validating incoming API resources.
    /// </summary>
    public interface IResourceValidator : IObjectValidator { }
}
