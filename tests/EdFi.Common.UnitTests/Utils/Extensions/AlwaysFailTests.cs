// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Common.UnitTests.Utils.Extensions
{
    public class AlwaysFailTests
    {
        [TestFixture]
        public class When_asserting_to_always_fail
        {
            [Test]
            public void Should_always_fail()
            {
                false.ShouldBeFalse();
            }
        }
    }
}