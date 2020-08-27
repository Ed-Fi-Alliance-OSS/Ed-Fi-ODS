// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using Test.Common;

namespace EdFi.Ods.Tests.EdFi.Ods.Common
{
    public class UtcTimeConverterTests
    {
        public class Times
        {
            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan TimeWithoutSeconds { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan TimeWithSeconds { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithPositiveUtcOffset { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithNegativeUtcOffset { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan TimeWithZSuffix { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan TimeWithZSuffixWithoutSeconds { get; set; }
        }

        public class NullableTimes
        {
            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithoutSeconds { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithSeconds { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithPositiveUtcOffset { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithNegativeUtcOffset { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithZSuffix { get; set; }

            [JsonConverter(typeof(UtcTimeConverter))]
            public TimeSpan? TimeWithZSuffixWithoutSeconds { get; set; }
        }

        [TestFixture]
        public class When_serializing_and_deserializing_time_values_from_JSON_to_nullable_or_non_nullable_times : LegacyTestFixtureBase
        {
            private Times times;
            private NullableTimes nullableTimes;
            private string serializedJson;
            private string serializedJsonForNullableTimes;
            private Times rolloverTimes;

            protected override void ExecuteBehavior()
            {
                times = JsonConvert.DeserializeObject<Times>(
                    @"
{
    ""TimeWithoutSeconds"":""07:57"", 
    ""TimeWithSeconds"":""07:57:32"", 
    ""TimeWithPositiveUtcOffset"":""07:57:32+05:00"", 
    ""TimeWithNegativeUtcOffset"":""07:57:32-05:00"", 
    ""TimeWithZSuffix"":""07:57:32Z"", 
    ""TimeWithZSuffixWithoutSeconds"":""07:57Z"" 
}");

                nullableTimes = JsonConvert.DeserializeObject<NullableTimes>(
                    @"
{
    ""TimeWithoutSeconds"":""07:57"", 
    ""TimeWithSeconds"":""07:57:32"", 
    ""TimeWithPositiveUtcOffset"":""07:57:32+05:00"", 
    ""TimeWithNegativeUtcOffset"":""07:57:32-05:00"", 
    ""TimeWithZSuffix"":""07:57:32Z"", 
    ""TimeWithZSuffixWithoutSeconds"":""07:57Z"" 
}");

                rolloverTimes = JsonConvert.DeserializeObject<Times>(
                    @"
{
    ""TimeWithoutSeconds"":""07:57"", 
    ""TimeWithSeconds"":""07:57:32"", 
    ""TimeWithPositiveUtcOffset"":""03:57:32+05:00"", 
    ""TimeWithNegativeUtcOffset"":""20:57:32-05:00"", 
    ""TimeWithZSuffix"":""07:57:32Z"", 
    ""TimeWithZSuffixWithoutSeconds"":""07:57Z"" 
}");

                serializedJson = JsonConvert.SerializeObject(times);
                serializedJsonForNullableTimes = JsonConvert.SerializeObject(nullableTimes);
            }

            [Test]
            public void Should_read_and_convert_time_with_negative_UTC_offset_to_GMT()
            {
                times.TimeWithNegativeUtcOffset.ShouldBe(new TimeSpan(12, 57, 32));
                nullableTimes.TimeWithNegativeUtcOffset.ShouldBe(new TimeSpan(12, 57, 32));
            }

            [Test]
            public void Should_read_and_convert_time_with_positive_UTC_offset_to_GMT()
            {
                times.TimeWithPositiveUtcOffset.ShouldBe(new TimeSpan(2, 57, 32));
                nullableTimes.TimeWithPositiveUtcOffset.ShouldBe(new TimeSpan(2, 57, 32));
            }

            [Test]
            public void Should_read_time_with_Z_suffix_and_no_seconds_as_GMT()
            {
                times.TimeWithZSuffixWithoutSeconds.ShouldBe(new TimeSpan(7, 57, 0));
                nullableTimes.TimeWithZSuffixWithoutSeconds.ShouldBe(new TimeSpan(7, 57, 0));
            }

            [Test]
            public void Should_read_time_with_Z_suffix_as_GMT()
            {
                times.TimeWithZSuffix.ShouldBe(new TimeSpan(7, 57, 32));
                nullableTimes.TimeWithZSuffix.ShouldBe(new TimeSpan(7, 57, 32));
            }

            [Test]
            public void Should_read_unspecified_time_with_seconds_as_GMT()
            {
                times.TimeWithSeconds.ShouldBe(new TimeSpan(7, 57, 32));
                nullableTimes.TimeWithSeconds.ShouldBe(new TimeSpan(7, 57, 32));
            }

            [Test]
            public void Should_read_unspecified_time_without_seconds_as_GMT()
            {
                times.TimeWithoutSeconds.ShouldBe(new TimeSpan(7, 57, 0));
                nullableTimes.TimeWithoutSeconds.ShouldBe(new TimeSpan(7, 57, 0));
            }

            [Test]
            public void Should_rollover_negative_UTC_offset_times_based_on_24_hour_clock()
            {
                rolloverTimes.TimeWithNegativeUtcOffset.ShouldBe(new TimeSpan(1, 57, 32));
            }

            [Test]
            public void Should_rollover_positive_UTC_offset_times_based_on_24_hour_clock()
            {
                rolloverTimes.TimeWithPositiveUtcOffset.ShouldBe(new TimeSpan(22, 57, 32));
            }

            [Test]
            public void Should_serialize_nullable_times_to_JSON_correctly()
            {
                // Approval-style test
                serializedJsonForNullableTimes.ShouldBe(
                    @"{""TimeWithoutSeconds"":""07:57:00"",""TimeWithSeconds"":""07:57:32"",""TimeWithPositiveUtcOffset"":""02:57:32"",""TimeWithNegativeUtcOffset"":""12:57:32"",""TimeWithZSuffix"":""07:57:32"",""TimeWithZSuffixWithoutSeconds"":""07:57:00""}");
            }

            [Test]
            public void Should_serialize_times_to_JSON_correctly()
            {
                // Approval-style test
                serializedJson.ShouldBe(
                    @"{""TimeWithoutSeconds"":""07:57:00"",""TimeWithSeconds"":""07:57:32"",""TimeWithPositiveUtcOffset"":""02:57:32"",""TimeWithNegativeUtcOffset"":""12:57:32"",""TimeWithZSuffix"":""07:57:32"",""TimeWithZSuffixWithoutSeconds"":""07:57:00""}");
            }
        }

        [TestFixture]
        public class When_deserializing_null_values_to_nullable_time_value_from_JSON : LegacyTestFixtureBase
        {
            private NullableTimes nullableTimes;
            private string serializedJsonForNullableTimes;

            protected override void ExecuteBehavior()
            {
                nullableTimes = JsonConvert.DeserializeObject<NullableTimes>(
                    @"
{
    ""TimeWithoutSeconds"":null, 
    ""TimeWithSeconds"":null, 
    ""TimeWithPositiveUtcOffset"":null, 
    ""TimeWithNegativeUtcOffset"":null, 
    ""TimeWithZSuffix"":null, 
    ""TimeWithZSuffixWithoutSeconds"":null 
}");

                serializedJsonForNullableTimes = JsonConvert.SerializeObject(nullableTimes);
                Console.WriteLine(serializedJsonForNullableTimes);
            }

            [Test]
            public void Should_read_null_values_as_null()
            {
                nullableTimes.TimeWithoutSeconds.ShouldBeNull();
                nullableTimes.TimeWithSeconds.ShouldBeNull();
                nullableTimes.TimeWithPositiveUtcOffset.ShouldBeNull();
                nullableTimes.TimeWithNegativeUtcOffset.ShouldBeNull();
                nullableTimes.TimeWithZSuffix.ShouldBeNull();
                nullableTimes.TimeWithZSuffixWithoutSeconds.ShouldBeNull();
            }

            [Test]
            public void Should_serialize_nullable_times_to_JSON_correctly()
            {
                // Approval-style test
                serializedJsonForNullableTimes.ShouldBe(
                    @"{""TimeWithoutSeconds"":null,""TimeWithSeconds"":null,""TimeWithPositiveUtcOffset"":null,""TimeWithNegativeUtcOffset"":null,""TimeWithZSuffix"":null,""TimeWithZSuffixWithoutSeconds"":null}");
            }
        }
    }
}
