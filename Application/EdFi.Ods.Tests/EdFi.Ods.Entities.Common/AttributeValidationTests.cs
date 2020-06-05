// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using EdFi.Ods.Api.Common.Attributes;
using EdFi.Ods.Api.Common.Validation;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Entities.Common
{
    public class SqlServerDateTimeRangeAttributeTests
    {
        [TestFixture]
        public class When_validating_a_sql_date_within_sql_server_range
        {
            [Test]
            public void Should_return_success()
            {
                var result = new SqlServerDateTimeRangeAttribute().IsValid(DateTime.Now);
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_a_null_sql_date
        {
            [Test]
            public void Should_return_succes()
            {
                var result = new SqlServerDateTimeRangeAttribute().IsValid(null);
                result.ShouldBeTrue();
            }
        }

        [TestFixture]
        public class When_validating_a_sql_date_outside_of_sql_server_range
        {
            [Test]
            public void Should_return_failure()
            {
                var result = new SqlServerDateTimeRangeAttribute().IsValid(new DateTime(1600, 01, 01));
                result.ShouldBeFalse();
            }
        }

        [TestFixture]
        public class When_validating_a_non_datetime_type
        {
            [Test]
            public void Should_throw_argument_exception()
            {
                Should.Throw<ArgumentException>(() => new SqlServerDateTimeRangeAttribute().IsValid(1));
            }
        }
    }
}
