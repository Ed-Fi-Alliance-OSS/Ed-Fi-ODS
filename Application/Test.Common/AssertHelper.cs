// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Test.Common
{
    public static class AssertHelper
    {
        /// <summary>
        /// Loops through the supplied asserts and execute all of them.
        /// Calls Assert.Fail with a message including all asserts that failed.
        /// </summary>
        /// <param name="asserts">Asserts to invoke</param>
        public static void All(params Action[] asserts)
        {
            var errorMessages = new List<Exception>();

            foreach (var assert in asserts)
            {
                try
                {
                    assert.Invoke();
                }
                catch (Exception exc)
                {
                    errorMessages.Add(exc);
                }
            }

            if (errorMessages.Any())
            {
                string separator = $"{Environment.NewLine}{Environment.NewLine}";
                string errorMessageString = string.Join(separator, errorMessages);

                Assert.Fail($"The following conditions failed:{Environment.NewLine}{errorMessageString}");
            }
        }
    }
}
