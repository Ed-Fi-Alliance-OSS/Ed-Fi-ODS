// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers.Partitions;

[TestFixture]
public class PartitionsQueryBuilderPartitionsApplicatorTests
{
    public enum Engine
    {
        SqlServer,
        PostgreSql
    }

    [TestCase(Engine.SqlServer, "true", true)]
    [TestCase(Engine.SqlServer, "True", true)]
    [TestCase(Engine.SqlServer, "false", false)]
    [TestCase(Engine.SqlServer, "yes", false)]
    [TestCase(Engine.SqlServer, null, false)]
    [TestCase(Engine.SqlServer, "", false)]
    [TestCase(Engine.PostgreSql, "true", true)]
    [TestCase(Engine.PostgreSql, "True", true)]
    [TestCase(Engine.PostgreSql, "false", false)]
    [TestCase(Engine.PostgreSql, "yes", false)]
    [TestCase(Engine.PostgreSql, null, false)]
    [TestCase(Engine.PostgreSql, "", false)]
    public void Should_allow_small_partitions_only_when_the_value_is_true(
        Engine engine,
        string value,
        bool expectSmallPartitions)
    {
        var sql = ApplyPartitions(
            engine,
            new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value },
            out var dialect);

        AssertPartitionSize(sql, dialect, expectSmallPartitions);
    }

    [TestCase(Engine.SqlServer)]
    [TestCase(Engine.PostgreSql)]
    public void Should_keep_the_minimum_partition_size_when_the_parameter_is_absent(Engine engine)
    {
        var sql = ApplyPartitions(engine, new Dictionary<string, string>(), out var dialect);

        AssertPartitionSize(sql, dialect, expectSmallPartitions: false);
    }

    [TestCase(Engine.SqlServer)]
    [TestCase(Engine.PostgreSql)]
    public void Should_match_the_parameter_name_in_any_case(Engine engine)
    {
        var sql = ApplyPartitions(
            engine,
            new Dictionary<string, string> { ["AllowSmallPartitions"] = "true" },
            out var dialect);

        AssertPartitionSize(sql, dialect, expectSmallPartitions: true);
    }

    private static void AssertPartitionSize(string sql, Dialect dialect, bool expectSmallPartitions)
    {
        string smallPartitionSize = dialect.GetGreatestString("1", "CEILING(CountOfRows / @numberOfPartitions)");

        string minimumPartitionSize = dialect.GetGreatestString(
            "CEILING(CountOfRows / @numberOfPartitions)",
            "(5 * @maxPageSize)");

        if (expectSmallPartitions)
        {
            sql.ShouldContain(smallPartitionSize);
            sql.ShouldNotContain(minimumPartitionSize);
        }
        else
        {
            sql.ShouldContain(minimumPartitionSize);
            sql.ShouldNotContain(smallPartitionSize);
        }
    }

    private static string ApplyPartitions(Engine engine, IDictionary<string, string> additionalParameters, out Dialect dialect)
    {
        var defaultPageSizeLimitProvider = A.Fake<IDefaultPageSizeLimitProvider>();
        A.CallTo(() => defaultPageSizeLimitProvider.GetDefaultPageSizeLimit()).Returns(500);

        IPartitionsQueryBuilderPartitionsApplicator applicator;

        switch (engine)
        {
            case Engine.SqlServer:
                dialect = new SqlServerDialect();
                applicator = new SqlServerPartitionsQueryBuilderPartitionsApplicator(dialect, defaultPageSizeLimitProvider, 5);
                break;
            case Engine.PostgreSql:
                dialect = new PostgreSqlDialect();
                applicator = new PostgreSqlPartitionsQueryBuilderPartitionsApplicator(dialect, defaultPageSizeLimitProvider, 5);
                break;
            default:
                throw new NotSupportedException();
        }

        return applicator.ApplyPartitions(
                new QueryBuilder(dialect).From("edfi.Student").Select("1"),
                null,
                additionalParameters)
            .BuildTemplate()
            .RawSql;
    }
}
