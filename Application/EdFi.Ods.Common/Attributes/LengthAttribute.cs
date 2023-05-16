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
            EnsureLegalLengths();

            string stringValue = value as string;

            int length = 0;

            if (value is string str)
            {
                length = stringValue.Length;
            }
            else if ((value.GetType()) != typeof(string))
            {
                throw new InvalidCastException(string.Format("The field of type {0} must be a string, array or ICollection type.", value.GetType()));
            }

            return (uint)(length - MinimumLength) <= (uint)(MaximumLength - MinimumLength) ? ValidationResult.Success
                : new ValidationResult(string.Format("{0} property is minimum length is {1} and maximum length is {2}.", validationContext.DisplayName,MinimumLength,MaximumLength));
        }

        private void EnsureLegalLengths()
        {
            if (MinimumLength < 0)
            {
                throw new InvalidOperationException("minLength must have a value that is zero or greater.");
            }

            if (MaximumLength < MinimumLength)
            {
                throw new InvalidOperationException("maxLength must have a value that is greater than or equal to minLength.");
            }
        }
    }
}
