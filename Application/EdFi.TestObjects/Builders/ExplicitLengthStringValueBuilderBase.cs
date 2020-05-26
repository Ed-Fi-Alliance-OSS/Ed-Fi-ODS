// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Generic;

namespace EdFi.TestObjects.Builders
{
    public abstract class ExplicitLengthStringValueBuilderBase : IValueBuilder
    {
        private readonly char[] _digitsAndCharacters;
        private int counter;

        protected ExplicitLengthStringValueBuilderBase()
        {
            var chars = new List<char>();

            for (char c = '0'; c <= '9'; c++)
            {
                chars.Add(c);
            }

            for (char c = 'A'; c <= 'Z'; c++)
            {
                chars.Add(c);
            }

            for (char c = 'a'; c <= 'z'; c++)
            {
                chars.Add(c);
            }

            _digitsAndCharacters = chars.ToArray();
        }

        public ITestObjectFactory Factory { get; set; }

        public ValueBuildResult TryBuild(BuildContext buildContext)
        {
            if (buildContext.TargetType != typeof(string))
            {
                return ValueBuildResult.NotHandled;
            }

            if (buildContext.ContainingType == null)
            {
                return ValueBuildResult.NotHandled;
            }

            int desiredLength;

            if (!TryGetLength(buildContext, out desiredLength))
            {
                return ValueBuildResult.NotHandled;
            }

            var value = BuildStringValue(desiredLength);

            string finalValue = value;

            // Generated value is too short - fill it with "x" characters
            if (value.Length < desiredLength)
            {
                var fillLength = desiredLength - value.Length;
                var eightKb = (int) Math.Pow(2, 10) * 8;
                var safeFillLength = Math.Min(fillLength, eightKb);
                var fill = new string('x', safeFillLength);

                finalValue = value + fill;
            }
            else if (value.Length > desiredLength)
            {
                finalValue = value.Substring(0, desiredLength);
            }

            return ValueBuildResult.WithValue(finalValue, buildContext.LogicalPropertyPath);
        }

        public void Reset()
        {
            counter = 0;
        }

        protected virtual string BuildStringValue(int desiredLength)
        {
            var firstChar = _digitsAndCharacters[counter % _digitsAndCharacters.Length];
            var value = string.Format("{0}-String-{1}", firstChar, counter++);

            // If value is longer than desired, trim to length and return
            if (desiredLength < value.Length)
            {
                return value.Substring(0, desiredLength);
            }

            return value;
        }

        /// <summary>
        /// Attempts to get the explicit length of the string to generate.
        /// </summary>
        /// <param name="buildContext">The context of the current value builder.</param>
        /// <returns></returns>
        protected abstract bool TryGetLength(BuildContext buildContext, out int length);
    }
}
