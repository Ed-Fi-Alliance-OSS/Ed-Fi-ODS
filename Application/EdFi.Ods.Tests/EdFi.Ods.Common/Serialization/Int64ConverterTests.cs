// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;
using EdFi.Ods.Common.Serialization;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    [TestFixture]
    public class Int64ConverterTests
    {
        private JsonSerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new JsonSerializer
            {
                Converters = { new Int64Converter() }
            };
        }

        private T Deserialize<T>(string json)
        {
            using var reader = new JsonTextReader(new StringReader(json));
            return _serializer.Deserialize<T>(reader);
        }

        public class TestLongContainer
        {
            [JsonConverter(typeof(Int64Converter))]
            public long Value { get; set; }
        }

        [TestCase("0", 0L)]
        [TestCase("1", 1L)]
        [TestCase("9", 9L)]
        [TestCase("42", 42L)]
        [TestCase("0123", 83L)]         // non-string with leading zeros, interpreted as Octal by JSON .NET and arrives at the converter as "83" typed as long
        [TestCase("\"0123\"", 123L)]     // string with leading zeros
        [TestCase("\"0123 \"", 123L)]     // string with leading zeros, trailing space
        [TestCase("\"0000000005\"", 5L)]
        [TestCase("\"0xA\"", 10L)]       // hex string
        [TestCase("\"0XfF\"", 255L)]     // hex uppercase
        [TestCase("\"\"", 0L)]           // empty string → default
        [TestCase("null", 0L)]           // null literal → default
        public void Should_parse_valid_inputs(string input, long expected)
        {
            var json = $"{{\"Value\": {input} }}";
            var result = Deserialize<TestLongContainer>(json);
            result.Value.ShouldBe(expected);
        }

        [TestCase("\"notanumber\"")]
        [TestCase("\"0xGG\"")]
        [TestCase("\"012398a\"")]
        public void Should_throw_on_invalid_inputs(string input)
        {
            var json = $"{{\"Value\": {input} }}";

            Should.Throw<JsonReaderException>(() => Deserialize<TestLongContainer>(json));
        }
    }
}
