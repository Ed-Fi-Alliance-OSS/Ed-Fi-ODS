// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;

namespace EdFi.Ods.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class LengthAttribute : ValidationAttribute
    {
        private readonly int _minimumlength;
        private readonly int _maximumlength;

        public LengthAttribute(int minimumLength, int maximumLength)
        {
            _maximumlength = maximumLength;
            _minimumlength = minimumLength;
        }

        public int MinimumLength
        {
            get { return _minimumlength; }
        }

        public int MaximumLength
        {
            get { return _maximumlength; }
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check the lengths for legality
            if (MinimumLength < 0)
            {
                return new ValidationResult(
                $"{validationContext.DisplayName} property is minimum length is {MinimumLength} and maximum length is {MaximumLength} .");
            }

            if (MaximumLength < MinimumLength)
            {
                return new ValidationResult(
                $"{validationContext.DisplayName} property is minimum length is {MinimumLength} and maximum length is {MaximumLength} .");
            }

            string stringValue = value as string;

            int length = 0;

            if (value is string str)
            {
                length = stringValue.Length;
            }
            else if ((value.GetType()) != typeof(string))
            {
                return new ValidationResult($"{validationContext.DisplayName} property is Invalid Value Type of {value.GetType()}.");
            }

            return (uint)(length - MinimumLength) <= (uint)(MaximumLength - MinimumLength) ? ValidationResult.Success
                : new ValidationResult(
                    $"{validationContext.DisplayName} property is minimum length is {MinimumLength} and maximum length is {MaximumLength} .");
        }
    }
}
