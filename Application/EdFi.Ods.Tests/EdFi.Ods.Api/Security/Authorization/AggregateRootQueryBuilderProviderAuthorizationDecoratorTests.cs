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
    [TestCase("UseJoinAuth", "true")]
    [TestCase("UseJoinAuth", "yes")]
    [TestCase("useJoinAuth", "true")]
    public void Should_not_let_the_caller_choose_the_authorization_filter_strategy(string parameterName, string value)
    {
        var queryBuilder = new QueryBuilder(new SqlServerDialect());
        queryBuilder.Context.SetQueryBuilderFilterStrategy(QueryBuilderFilterStrategy.ExistsSubquery);

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

        var result = decorator.GetQueryBuilder(
            null,
            null,
            A.Fake<IQueryParameters>(),
            new Dictionary<string, string> { [parameterName] = value });

        result.Context.UsesExistsSubqueryFilterStrategy().ShouldBeTrue();
        result.Context.UsesJoinFilterStrategy().ShouldBeFalse();
    }
}
