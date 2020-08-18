// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using NUnit.Framework;

namespace EdFi.Ods.Tests._Extensions
{
    public static class ExceptionAssertionExtensions
    {
        public static void ShouldBeExceptionType<TExpected>(this Exception exception)
        {
            if (exception == null)
            {
                Assert.That(exception, Is.TypeOf<TExpected>());
            }
            else
            {
                Assert.That(exception, Is.TypeOf<TExpected>(), GetActualExceptionOutputMessage(exception));
            }
        }

        private static string GetActualExceptionOutputMessage(Exception exception)
        {
            return "Actual Exception: " + exception + "\r\n---------------------------------------------";
        }

        public static void MessageShouldContain(this Exception exception, string expectedSubstring)
        {
            Assert.That(exception?.Message, Does.Contain(expectedSubstring), 
                $@"Exception message does not contain the expected text.
Actual Exception: {exception}");
        }

        public static void ShouldBeNull(this Exception exception)
        {
            Assert.That(exception, Is.Null, GetActualExceptionOutputMessage(exception));
        }
    }
}
