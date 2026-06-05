// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EdFi.Ods.Common.Attributes;

/// <summary>
/// Provides date validation using supplied inclusive minimum and maximum date values.
/// </summary>
public class DateRangeAttribute : ValidationAttribute
{
    private readonly DateTime _minDate;
    private readonly DateTime _maxDate;
    private readonly string _formattedMinDate;
    private readonly string _formattedMaxDate;

    public DateRangeAttribute(string minimumDate, string maximumDate)
    {
        if (!DateTime.TryParse(minimumDate, out _minDate))
        {
            throw new ArgumentException("Invalid format for minimum date.");
        }

        if (!DateTime.TryParse(maximumDate, out _maxDate))
        {
            throw new ArgumentException("Invalid format for maximum date.");
        }

        // Ensure the comparison is done only on the date part
        _minDate = _minDate.Date;
        _maxDate = _maxDate.Date;

        // Preformat the dates for use in messages
        _formattedMinDate = _minDate.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        _formattedMaxDate = _maxDate.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        // Set a default error message
        ErrorMessage = "{0} must be a date between {1} and {2}.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            // If the property is nullable and not required, null is valid.
            // If it's required, use [Required] alongside this attribute.
            return ValidationResult.Success;
        }

        if (value is DateTime dateTimeValue)
        {
            // Compare only the date part
            if (dateTimeValue.Date >= _minDate && dateTimeValue.Date <= _maxDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                // Format the error message to show only dates
                return new ValidationResult(
                    string.Format(ErrorMessage, validationContext.MemberName, _formattedMinDate, _formattedMaxDate),
                    new[] { validationContext.MemberName });
            }
        }
        
        // Handle cases where the property type is not DateTime
        throw new Exception($"The {nameof(DateRangeAttribute)} attribute can only be applied to properties of type DateTime.");
    }
}
