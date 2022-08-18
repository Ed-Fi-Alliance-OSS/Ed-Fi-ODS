// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.TestFixture;
using NUnit.Framework;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Validation
{
 public class When_validating_always_failing_test : TestFixtureBase
    {
        [Assert]
        public void Should_always_fail()
        {
            Assert.Equals(1, 2);
        }
    }
}