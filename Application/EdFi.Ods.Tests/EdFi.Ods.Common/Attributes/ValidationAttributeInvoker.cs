// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class ValidationAttributeHelper
{
    /// <summary>
    /// Invokes the protected IsValid method (with ValidationContext) using reflection.
    /// </summary>
    /// <param name="attribute">The ValidationAttribute to invoke.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="validationContext">The ValidationContext to provide.</param>
    /// <returns>The ValidationResult returned by the IsValid method.</returns>
    public static ValidationResult InvokeIsValid(
        ValidationAttribute attribute, 
        object value, 
        ValidationContext validationContext)
    {
        if (attribute == null)
        {
            throw new ArgumentNullException(nameof(attribute));
        }

        // Find the protected IsValid method using reflection
        var isValidMethod = attribute.GetType()
            .GetMethod("IsValid", BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                new Type[] { typeof(object), typeof(ValidationContext) }, 
                null);
        
        if (isValidMethod == null)
        {
            throw new InvalidOperationException(
                "Could not find the protected IsValid(object, ValidationContext) method.");
        }

        // Invoke the IsValid method and return the result
        return isValidMethod.Invoke(attribute, new object[] { value, validationContext })
            as ValidationResult;
    }
}
