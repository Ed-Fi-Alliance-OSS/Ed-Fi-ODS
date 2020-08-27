// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    [TestFixture]
    public class Iso8601UtcDateOnlyConverterTests
    {
        private class DateTimes
        {
            [JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
            public DateTime DateTimeOnly { get; set; }

            [JsonConverter(typeof(Iso8601UtcDateOnlyConverter))]
            public DateTime? NullableDateTimeOnly { get; set; }
        }

        [TestFixture]
        public class
            When_serializing_and_deserializing_datetime_values_from_JSON_to_nullable_or_non_nullable_datetimes :
                LegacyTestFixtureBase
        {
            private DateTimes datetimes;
            private string serializedJson;

            protected override void ExecuteBehavior()
            {
                datetimes = DefaultTestJsonSerializer.DeserializeObject<DateTimes>(
                    @"
{
    ""DateTimeOnly"":""2014-08-01"", 
    ""NullableDateTimeOnly"":""2014-08-01""
}");

                serializedJson = JsonConvert.SerializeObject(datetimes);
            }

            [Test]
            public void Should_read_datetime_only()
            {
                AssertHelper.All(
                    () => Assert.That(datetimes.DateTimeOnly, Is.EqualTo(new DateTime(2014, 8, 1))),
                    () => Assert.That(datetimes.NullableDateTimeOnly, Is.EqualTo(new DateTime(2014, 8, 1))));
            }

            [Test]
            public void Should_serialize_datetimes_to_JSON_correctly()
            {
                Assert.That(serializedJson, Is.EqualTo(@"{""DateTimeOnly"":""2014-08-01"",""NullableDateTimeOnly"":""2014-08-01""}"));
            }
        }

        [TestFixture]
        public class When_deserializing_null_values_to_nullable_datetime_value_from_JSON : LegacyTestFixtureBase
        {
            private DateTimes nullableDateTimes;
            private string serializedJsonForNullableDateTimes;

            protected override void ExecuteBehavior()
            {
                nullableDateTimes = DefaultTestJsonSerializer.DeserializeObject<DateTimes>(
                    @"
{
    ""DateTimeOnly"":""2014-08-01"",
    ""NullableDateTimeOnly"":null
}");

                serializedJsonForNullableDateTimes = JsonConvert.SerializeObject(nullableDateTimes);
            }

            [Test]
            public void Should_read_null_value_as_null()
            {
                Assert.That(nullableDateTimes.NullableDateTimeOnly, Is.Null);
            }

            [Test]
            public void Should_serialize_nullable_datetimes_to_JSON_correctly()
            {
                Assert.That(serializedJsonForNullableDateTimes, Is.EqualTo(@"{""DateTimeOnly"":""2014-08-01"",""NullableDateTimeOnly"":null}"));
            }
        }

        [TestFixture]
        public class When_deserializing_with_datetime_parse_enabled
        {
            [Test]
            public void Should_throw_application_exception()
            {
                Should.Throw<ApplicationException>(
                    () =>
                        JsonConvert.DeserializeObject<DateTimes>(
                            @"
{
    ""DateTimeOnly"":""2014-08-01T07:57:32Z""
}"));
            }
        }

        [TestFixture]
        public class When_deserializing_datetime_values_with_time_portion
        {
            [TestCase("2014-08-01T07:57")]
            [TestCase("2014-08-01T07:57:32")]
            [TestCase("2014-08-01T07:57:32+05:00")]
            [TestCase("2014-08-01T07:57:32-05:00")]
            [TestCase("2014-08-01T07:57:32Z")]
            [TestCase("2014-08-01T07:57Z")]
            [TestCase("2014-08-01T")]
            [TestCase("2014-08-01 07:57")]
            [TestCase("2014-08-01 07:57:32")]
            [TestCase("2014-08-01 07:57:32+05:00")]
            [TestCase("2014-08-01 07:57:32-05:00")]
            [TestCase("2014-08-01 07:57:32Z")]
            [TestCase("2014-08-01 07:57Z")]
            [TestCase("11am")]
            [TestCase("11pm")]
            [TestCase("23pm")]
            [TestCase("11 AM")]
            [TestCase("11 PM")]
            [TestCase("2014-08-0107:57Z")]
            public void Should_throw_format_exception(string dateTimeValue)
            {
                Should.Throw<FormatException>(
                    () =>
                        DefaultTestJsonSerializer.DeserializeObject<DateTimes>(
                            @"
{
    ""DateTimeOnly"":""" + dateTimeValue + @"""
}"));
            }
        }

        [TestFixture]
        public class When_deserializing_valid_date_only_values
        {
            [TestCase("2014-08-01", 2014, 08, 01)]
            [TestCase("08-01-2014", 2014, 08, 01)]
            [TestCase("2014/08/01", 2014, 08, 01)]
            [TestCase("08/01/2014", 2014, 08, 01)]
            [TestCase("Aug 01, 2014", 2014, 08, 01)]
            [TestCase("Aug 01", null, 08, 01)]
            [TestCase("08/01", null, 08, 01)]
            [TestCase("08/2014", 2014, 08, 01)]
            [TestCase("2014/08", 2014, 08, 01)]
            public void Should_deserialize_to_valid_value(string dateTimeValue, int? expectedYear, int? expectedMonth, int? expectedDay)
            {
                var dateTimesObject = DefaultTestJsonSerializer.DeserializeObject<DateTimes>(
                    @"
{
    ""DateTimeOnly"":""" + dateTimeValue + @"""
}");

                var now = DateTime.Now;
                Assert.That(dateTimesObject.DateTimeOnly, Is.EqualTo(new DateTime(expectedYear ?? now.Year, expectedMonth ?? now.Month, expectedDay ?? now.Day)));
            }
        }

        public class When_deserializing_datetime_values_with_invalid_format : LegacyTestFixtureBase
        {
            private Exception expectedException;
            private DateTimes deserializedObject;

            protected override void ExecuteBehavior()
            {
                try
                {
                    deserializedObject = DefaultTestJsonSerializer.DeserializeObject<DateTimes>(
                        @"
{
    ""DateTimeOnly"":""2014-08-01T07:57:32Z""
}");
                }
                catch (Exception e)
                {
                    expectedException = e;
                }

            }

            [Test]
            public void Should_throw_format_exception_with_date_message()
            {
                AssertHelper.All(
                    () => Assert.That(deserializedObject, Is.Null),
                    () => Assert.That(expectedException, Is.Not.Null),
                    () => Assert.That(expectedException?.GetType(), Is.EqualTo(typeof(FormatException))),
                    () => Assert.That(expectedException?.Message?.Contains("DateTime"), Is.False),
                    () => Assert.That(expectedException?.Message?.Contains("date"), Is.True));
            }
        }
    }
}
