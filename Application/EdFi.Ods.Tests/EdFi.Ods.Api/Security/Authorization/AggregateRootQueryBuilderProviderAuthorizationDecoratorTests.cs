// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization;

[TestFixture]
public class AggregateRootQueryBuilderProviderAuthorizationDecoratorTests
{
    // The decorator used to read "UseJoinAuth" (capital U) and switch the query to the join-based filter
    [TestCase("true", TestName = "Should_not_switch_to_joins_on_UseJoinAuth_true")]
    [TestCase("yes", TestName = "Should_not_throw_on_non_boolean_UseJoinAuth")]
    public void Should_keep_the_server_strategy_when_the_caller_sends_UseJoinAuth(string value)
    {
        var queryBuilder = new QueryBuilder(new SqlServerDialect());
        queryBuilder.Context.SetQueryBuilderFilterStrategy(QueryBuilderFilterStrategy.ExistsSubquery);

        var result = GetQueryBuilder(queryBuilder, new Dictionary<string, string> { ["UseJoinAuth"] = value });

        result.Context.UsesExistsSubqueryFilterStrategy().ShouldBeTrue();
        result.Context.UsesJoinFilterStrategy().ShouldBeFalse();
    }

    [Test]
    public void Should_keep_the_default_cte_strategy_for_get_all_when_the_caller_sends_UseJoinAuth()
    {
        // GET all sets no strategy, so the CTE filter is used
        var result = GetQueryBuilder(
            new QueryBuilder(new SqlServerDialect()),
            new Dictionary<string, string> { ["UseJoinAuth"] = "true" });

        result.Context.UsesCteFilterStrategy().ShouldBeTrue();
        result.Context.UsesJoinFilterStrategy().ShouldBeFalse();
    }

    private static QueryBuilder GetQueryBuilder(QueryBuilder queryBuilder, IDictionary<string, string> additionalParameters)
    {

        var decoratedInstance = A.Fake<IAggregateRootQueryBuilderProvider>();

        A.CallTo(
                () => decoratedInstance.GetQueryBuilder(
                    A<Entity>._,
                    A<AggregateRootWithCompositeKey>._,
                    A<IQueryParameters>._,
                    A<IDictionary<string, string>>._))
            .Returns(queryBuilder);

        var authorizationPlanContextProvider = A.Fake<IContextProvider<DataManagementAuthorizationPlan>>();

        A.CallTo(() => authorizationPlanContextProvider.Get())
            .Returns(new DataManagementAuthorizationPlan { Filtering = Array.Empty<AuthorizationStrategyFiltering>() });

        var decorator = new AggregateRootQueryBuilderProviderAuthorizationDecorator(
            decoratedInstance,
            authorizationPlanContextProvider,
            A.Fake<IAuthorizationFilterDefinitionProvider>());

        return decorator.GetQueryBuilder(null, null, A.Fake<IQueryParameters>(), additionalParameters);
    }
}
