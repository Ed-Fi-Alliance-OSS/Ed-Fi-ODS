// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Data;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.TestFixture;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Models.Domain
{
    [TestFixture]
    public class PropertyTypeTests
    {
        public abstract class When_creating_a_PropertyType : TestFixtureBase
        {
            public class With_a_negative_precision : When_creating_a_PropertyType
            {
                protected override void Act()
                {
                    new PropertyType(DbType.Int32, 0, -1, 0);
                }
            }

            public class With_a_negative_scale : When_creating_a_PropertyType
            {
                protected override void Act()
                {
                    new PropertyType(DbType.Int32, 0, 1, -1);
                }
            }

            public class With_a_scale_greater_than_the_precision : When_creating_a_PropertyType
            {
                protected override void Act()
                {
                    new PropertyType(DbType.Int32, 0, 1, 2);
                }
            }

            [Test]
            public void Should_throw_an_exception()
            {
                var problemDetails = ActualException.ShouldBeOfType<InvalidApiModelException>();

                AssertHelper.All(
                    () => problemDetails.Status.ShouldBe(500),
                    () => problemDetails.Type.ShouldBe(string.Join(':', EdFiProblemDetailsExceptionBase.BaseTypePrefix, "system:configuration:invalid:api-model")),
                    () => problemDetails.Detail.ShouldBe("The system configuration is invalid. Details are available in the server logs using the supplied correlation id.")
                );
            }
        }
    }
}