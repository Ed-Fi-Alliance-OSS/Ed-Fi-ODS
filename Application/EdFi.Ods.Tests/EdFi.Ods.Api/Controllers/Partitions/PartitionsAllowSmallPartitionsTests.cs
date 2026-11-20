// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Repositories;
using EdFi.Ods.Common.Logging;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Controllers.Partitions
{
    [TestFixture]
    public class PartitionsControllerAllowSmallPartitionsTests
    {
        [TestCase("yes")]
        [TestCase("1")]
        [TestCase("")]
        [TestCase("true; DROP TABLE x")]
        public async Task Should_return_bad_request_when_the_value_is_not_a_boolean(string value)
        {
            var controller = BuildController();

            var result = await controller.Get(
                null,
                new UrlQueryParametersRequest(),
                new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value });

            var badRequest = result.ShouldBeOfType<BadRequestObjectResult>();
            var problemDetails = badRequest.Value.ShouldBeAssignableTo<IEdFiProblemDetails>();
            problemDetails.Errors.ShouldContain("The 'allowSmallPartitions' parameter must be 'true' or 'false'.");
        }

        [TestCase("true")]
        [TestCase("True")]
        [TestCase("false")]
        [TestCase("FALSE")]
        public async Task Should_accept_a_boolean_value(string value)
        {
            // The fake resource context has no resource, so a request that passes validation ends in 404.
            var controller = BuildController();

            var result = await controller.Get(
                null,
                new UrlQueryParametersRequest(),
                new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value });

            result.ShouldBeAssignableTo<IStatusCodeActionResult>().StatusCode.ShouldBe(StatusCodes.Status404NotFound);
        }

        private static PartitionsController BuildController()
        {
            var personTypesProvider = A.Fake<IPersonTypesProvider>();
            A.CallTo(() => personTypesProvider.PersonTypes).Returns(Array.Empty<string>());

            var resourceContextProvider = A.Fake<IContextProvider<DataManagementResourceContext>>();
            A.CallTo(() => resourceContextProvider.Get()).Returns(null);

            return new PartitionsController(
                A.Fake<DbProviderFactory>(),
                resourceContextProvider,
                A.Fake<IOdsDatabaseConnectionStringProvider>(),
                A.Fake<ILogContextAccessor>(),
                A.Fake<IPartitionsQueryBuilderProvider>(),
                personTypesProvider,
                A.Fake<IContextProvider<UsiLookupsByUniqueIdContext>>(),
                A.Fake<IContextualPersonUsisResolver>());
        }
    }

    [TestFixture]
    public class PartitionsApplicatorAllowSmallPartitionsTests
    {
        public enum Engine
        {
            SqlServer,
            PostgreSql
        }

        private const string MinimumPartitionSizeExpression = "5 * @maxPageSize";

        [TestCase(Engine.SqlServer, "true", false)]
        [TestCase(Engine.SqlServer, "True", false)]
        [TestCase(Engine.SqlServer, "false", true)]
        [TestCase(Engine.SqlServer, "yes", true)]
        [TestCase(Engine.SqlServer, "", true)]
        [TestCase(Engine.SqlServer, null, true)]
        [TestCase(Engine.PostgreSql, "true", false)]
        [TestCase(Engine.PostgreSql, "True", false)]
        [TestCase(Engine.PostgreSql, "false", true)]
        [TestCase(Engine.PostgreSql, "yes", true)]
        [TestCase(Engine.PostgreSql, "", true)]
        [TestCase(Engine.PostgreSql, null, true)]
        public void Should_keep_the_minimum_partition_size_unless_the_value_is_true(
            Engine databaseEngine,
            string value,
            bool expectMinimumPartitionSize)
        {
            var additionalParameters = value == null
                ? new Dictionary<string, string>()
                : new Dictionary<string, string> { [PartitionsParameters.AllowSmallPartitions] = value };

            var (dialect, applicator) = BuildApplicator(databaseEngine);

            var queryBuilder = applicator.ApplyPartitions(
                new QueryBuilder(dialect).From("edfi.Student").Select("1"),
                null,
                additionalParameters);

            string sql = queryBuilder.BuildTemplate().RawSql;

            if (expectMinimumPartitionSize)
            {
                sql.ShouldContain(MinimumPartitionSizeExpression);
            }
            else
            {
                sql.ShouldNotContain(MinimumPartitionSizeExpression);
            }
        }

        private static (Dialect, IPartitionsQueryBuilderPartitionsApplicator) BuildApplicator(Engine databaseEngine)
        {
            var defaultPageSizeLimitProvider = A.Fake<IDefaultPageSizeLimitProvider>();
            A.CallTo(() => defaultPageSizeLimitProvider.GetDefaultPageSizeLimit()).Returns(500);

            return databaseEngine switch
            {
                Engine.SqlServer => (
                    new SqlServerDialect(),
                    new SqlServerPartitionsQueryBuilderPartitionsApplicator(new SqlServerDialect(), defaultPageSizeLimitProvider, 5)),
                Engine.PostgreSql => (
                    new PostgreSqlDialect(),
                    new PostgreSqlPartitionsQueryBuilderPartitionsApplicator(new PostgreSqlDialect(), defaultPageSizeLimitProvider, 5)),
                _ => throw new NotSupportedException()
            };
        }
    }
}
