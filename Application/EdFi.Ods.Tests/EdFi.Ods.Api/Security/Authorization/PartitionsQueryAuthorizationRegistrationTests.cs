// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using Autofac;
using EdFi.Common.Configuration;
using EdFi.Ods.Api.Container.Modules;
using EdFi.Ods.Api.Controllers.Partitions.Controllers;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Api.Security.Authorization.Repositories;
using EdFi.Ods.Api.Security.Container.Modules;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.Authorization;

/// <summary>
/// The partitions query builder is registered with a key. These tests check that the authorization decorator
/// still wraps it, so the partitions endpoint applies the same authorization filters as the GET all endpoints.
/// </summary>
[TestFixture]
public class PartitionsQueryAuthorizationRegistrationTests
{
    private IContainer _container;

    [OneTimeSetUp]
    public void OneTimeSetUp() => _container = BuildContainer(_ => { });

    [OneTimeTearDown]
    public void OneTimeTearDown() => _container?.Dispose();

    private static IContainer BuildContainer(Action<ContainerBuilder> overrideRegistrations)
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule(new KeySetPagingModule());
        builder.RegisterModule(new SecurityPersistenceModule());

        builder.RegisterInstance<Dialect>(new SqlServerDialect());
        builder.RegisterInstance(DatabaseEngine.SqlServer);
        builder.RegisterInstance(A.Fake<IAuthorizationContextProvider>());
        builder.RegisterInstance(A.Fake<IDataManagementAuthorizationPlanFactory>());
        builder.RegisterInstance(A.Fake<IContextProvider<DataManagementAuthorizationPlan>>());
        builder.RegisterInstance(A.Fake<ISecurityRepository>());
        builder.RegisterInstance(A.Fake<IResourceClaimUriProvider>());
        builder.RegisterInstance(A.Fake<IAuthorizationFilterDefinitionProvider>());
        builder.RegisterInstance(A.Fake<IPartitionsQueryBuilderPartitionsApplicator>());

        // The fakes above only satisfy the dependencies of the two modules

        overrideRegistrations(builder);

        return builder.Build();
    }

    [Test]
    public void Should_decorate_the_keyed_partitions_row_numbers_query_builder_with_authorization()
    {
        var queryBuilderProvider = _container.ResolveKeyed<IAggregateRootQueryBuilderProvider>(
            PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey);

        queryBuilderProvider.ShouldBeOfType<AggregateRootQueryBuilderProviderAuthorizationDecorator>();
    }

    [Test]
    public void Should_authorize_the_row_numbers_query_of_the_partitions_query()
    {
        var rowNumbersQueryBuilderProvider = A.Fake<IAggregateRootQueryBuilderProvider>();

        A.CallTo(
                () => rowNumbersQueryBuilderProvider.GetQueryBuilder(
                    A<Entity>._,
                    A<AggregateRootWithCompositeKey>._,
                    A<IQueryParameters>._,
                    A<IDictionary<string, string>>._))
            .ReturnsLazily(() => new QueryBuilder(new SqlServerDialect()));

        var authorizationPlanContextProvider = A.Fake<IContextProvider<DataManagementAuthorizationPlan>>();

        A.CallTo(() => authorizationPlanContextProvider.Get())
            .Returns(new DataManagementAuthorizationPlan { Filtering = Array.Empty<AuthorizationStrategyFiltering>() });

        // Replaces only the inner query builder and the plan; the registrations and the decorator come from the modules
        using var container = BuildContainer(
            builder =>
            {
                builder.RegisterInstance(rowNumbersQueryBuilderProvider)
                    .Keyed<IAggregateRootQueryBuilderProvider>(PartitionRowNumbersCteQueryBuilderProvider.RegistrationKey);

                builder.RegisterInstance(authorizationPlanContextProvider);
            });

        container.Resolve<IPartitionsQueryBuilderProvider>()
            .GetQueryBuilder(1, null, null, new QueryParameters(), new Dictionary<string, string>());

        A.CallTo(() => rowNumbersQueryBuilderProvider.GetQueryBuilder(
                A<Entity>._,
                A<AggregateRootWithCompositeKey>._,
                A<IQueryParameters>._,
                A<IDictionary<string, string>>._))
            .MustHaveHappenedOnceExactly();

        A.CallTo(() => authorizationPlanContextProvider.Get()).MustHaveHappenedOnceExactly();
    }
}
