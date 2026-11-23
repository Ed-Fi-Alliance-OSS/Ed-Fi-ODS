// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Database.Querying;
using EdFi.Ods.Common.Database.Querying.Dialects;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Definitions.Transformers;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Providers.Queries;
using EdFi.Ods.Common.Security.Authorization;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships.Filters
{
    [TestFixture]
    public class QueryBuilderExtensionsFilterStrategyTests
    {
        // The key the removed useJoinAuth query parameter used to set for the request
        private const string UseJoinAuthKey = "UseJoinAuth";

        private readonly CallContextStorage _callContextStorage = new();

        [TearDown]
        public void TearDown() => _callContextStorage.SetValue(UseJoinAuthKey, null);

        [Test]
        public void Should_not_let_the_call_context_switch_the_authorization_filter_to_joins()
        {
            _callContextStorage.SetValue(UseJoinAuthKey, true);

            var queryBuilder = new QueryBuilder(new SqlServerDialect());
            queryBuilder.Context.SetQueryBuilderFilterStrategy(QueryBuilderFilterStrategy.ExistsSubquery);
            queryBuilder.From($"edfi.Something AS {AliasConstants.RootAlias}");
            queryBuilder.Select($"{AliasConstants.RootAlias}.EducationOrganizationId");

            queryBuilder.ApplySingleColumnJoinFilter(
                CreateResource(),
                new Dictionary<string, object>
                {
                    [RelationshipAuthorizationConventions.ClaimsParameterName] = new object[] { 255901 }
                },
                "EducationOrganizationIdToEducationOrganizationId",
                "EducationOrganizationId",
                "SourceEducationOrganizationId",
                "TargetEducationOrganizationId",
                JoinType.InnerJoin);

            string sql = queryBuilder.BuildTemplate().RawSql;

            sql.ShouldContain("EXISTS");
            sql.ShouldNotContain("JOIN", Case.Insensitive);
        }

        private static Resource CreateResource()
        {
            var definitions = new DomainModelDefinitions(
                new SchemaDefinition("Ed-Fi", "edfi"),
                new AggregateDefinition[] { new("edfi.Something", new FullName[] { new("edfi.Something") }) },
                new EntityDefinition[]
                {
                    new(
                        "edfi",
                        "Something",
                        new EntityPropertyDefinition[]
                        {
                            new("EducationOrganizationId", new PropertyType(DbType.Int64), isIdentifying: true)
                        },
                        new EntityIdentifierDefinition[] { new("Something_PK", new[] { "EducationOrganizationId" }, isPrimary: true) })
                },
                Array.Empty<AssociationDefinition>(),
                Array.Empty<AggregateExtensionDefinition>());

            var definitionsProvider = A.Fake<IDomainModelDefinitionsProvider>();
            A.CallTo(() => definitionsProvider.GetDomainModelDefinitions()).Returns(definitions);

            var domainModelProvider = new DomainModelProvider(
                new[] { definitionsProvider },
                Array.Empty<IDomainModelDefinitionsTransformer>());

            return new ResourceModel(domainModelProvider.GetDomainModel()).GetAllResources().Single();
        }
    }
}
