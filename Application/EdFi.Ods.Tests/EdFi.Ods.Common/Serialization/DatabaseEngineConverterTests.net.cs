// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Common.Serialization
{
    [TestFixture]
    public class DatabaseEngineConverterTests
    {
        [Test]
        public void Should_deserialize_valid_database_engine()
        {
            var result = JsonConvert.DeserializeObject<DatabaseEngine>(
                $"\"{ApiConfigurationConstants.PostgreSQL}\"", new DatabaseEngineConverter());

            result.ShouldBe(DatabaseEngine.Postgres);
        }

        [Test]
        public void Should_serialize_database_engine_to_value()
        {
            string result = JsonConvert.SerializeObject(
                DatabaseEngine.SqlServer, Formatting.Indented, new DatabaseEngineConverter());

            result.ShouldNotBeEmpty();
            result.ShouldNotBeNull();
            result.ShouldBe($"\"{DatabaseEngine.SqlServer.Value}\"");
        }

        [Test]
        public void Should_serialize_null_database_engine_to_value()
        {
            string result = JsonConvert.SerializeObject(null, Formatting.Indented, new DatabaseEngineConverter());

            result.ShouldNotBeEmpty();
            result.ShouldNotBeNull();
            result.ShouldBe("null");
        }

        [Test]
        public void Should_throw_exception_for_deserialize_invalid_database_engine()
        {
            Should.Throw<ArgumentException>(
                () => JsonConvert.DeserializeObject<DatabaseEngine>(null, new DatabaseEngineConverter()));
        }
    }
}
