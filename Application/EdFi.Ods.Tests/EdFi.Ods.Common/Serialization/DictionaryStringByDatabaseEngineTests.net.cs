// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    [TestFixture]
    public class DictionaryStringByDatabaseEngineTests
    {
        [Test]
        public void Should_serialize_dictionary_with_values()
        {
            var stringByDatabaseName = new Dictionary<DatabaseEngine, string> {{DatabaseEngine.SqlServer, "column"}};

            string result = JsonConvert.SerializeObject(
                stringByDatabaseName, Formatting.None, new DictionaryStringByDatabaseEngine());

            result.ShouldNotBeEmpty();
            result.ShouldNotBeNull();
            result.ShouldBe($"{{\"{ApiConfigurationConstants.SqlServer}\":\"column\"}}");
        }

        [Test]
        public void Should_serialize_dictionary_with_empty_values()
        {
            var stringByDatabaseName = new Dictionary<DatabaseEngine, string>();

            string result = JsonConvert.SerializeObject(
                stringByDatabaseName, Formatting.None, new DictionaryStringByDatabaseEngine());

            result.ShouldNotBeEmpty();
            result.ShouldNotBeNull();
            result.ShouldBe("{}");
        }

        [Test]
        public void Should_serialize_dictionary_with_null_values()
        {
            string result = JsonConvert.SerializeObject(null, Formatting.None, new DictionaryStringByDatabaseEngine());

            result.ShouldNotBeEmpty();
            result.ShouldNotBeNull();
            result.ShouldBe("null");
        }

        [Test]
        public void Should_deserialize_dictionary_with_values()
        {
            var dict = new Dictionary<string, string> {{ApiConfigurationConstants.PostgreSQL, "column"}};
            string source = JsonConvert.SerializeObject(dict);

            var result = JsonConvert.DeserializeObject<IDictionary<DatabaseEngine, string>>(
                source, new DictionaryStringByDatabaseEngine());

            result.ShouldNotBeNull();
            result.Keys.Count.ShouldBe(1);
            result.ContainsKey(DatabaseEngine.Postgres);
        }

        [Test]
        public void Should_throw_when_deserialize_dictionary_with_invalid_values()
        {
            var dict = new Dictionary<string, string> {{"invalid", "column"}};
            string source = JsonConvert.SerializeObject(dict);

            Should.Throw<ArgumentException>(
                () => JsonConvert.DeserializeObject<IDictionary<DatabaseEngine, string>>(
                    source, new DictionaryStringByDatabaseEngine()));
        }

        [Test]
        public void Should_deserialize_empty_dictionary_with_no_values()
        {
            var dict = new Dictionary<string, string>();
            string source = JsonConvert.SerializeObject(dict);

            var result = JsonConvert.DeserializeObject<IDictionary<DatabaseEngine, string>>(
                source, new DictionaryStringByDatabaseEngine());

            result.ShouldNotBeNull();
            result.Keys.Count.ShouldBe(0);
        }

        [Test]
        public void Should_throw_when_deserialize_null_dictionary()
        {
            Should.Throw<ArgumentNullException>(
                () => JsonConvert.DeserializeObject<IDictionary<DatabaseEngine, string>>(
                    null, new DictionaryStringByDatabaseEngine()));
        }
    }
}
