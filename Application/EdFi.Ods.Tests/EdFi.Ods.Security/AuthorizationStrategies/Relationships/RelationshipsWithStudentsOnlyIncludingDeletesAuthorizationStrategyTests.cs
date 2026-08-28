// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;
using EdFi.Ods.Common.Attributes;
using EdFi.Ods.Common.Models;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Common.Specifications;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Api.Security.AuthorizationStrategies.Relationships;

[TestFixture]
public class RelationshipsWithStudentsOnlyIncludingDeletesAuthorizationStrategyTests
{
    private const string IncludingDeletes = "IncludingDeletes";

    private IDomainModelProvider _domainModelProvider;
    private IPersonEntitySpecification _personEntitySpecification;

    [SetUp]
    public void SetUp()
    {
        _domainModelProvider = A.Fake<IDomainModelProvider>();

        var personTypesProvider = A.Fake<IPersonTypesProvider>();

        A.CallTo(() => personTypesProvider.PersonTypes)
            .Returns(new[] { "Student", "Staff", "Parent", "Contact" });

        _personEntitySpecification = new PersonEntitySpecification(personTypesProvider);
    }

    [Test]
    public void GetAuthorizationSubjectEndpoints_ShouldReturnOnlyStudentEndpoint_WhenContextContainsStudentAndContact()
    {
        // Arrange
        var strategy = new TestableStrategy(_domainModelProvider, _personEntitySpecification);

        var authorizationContextTuples = new (string name, object value)[]
        {
            ("StudentUSI", 100),
            ("ContactUSI", 200),
        };

        // Act
        var subjectEndpoints = strategy.GetSubjectEndpoints(authorizationContextTuples);

        // Assert
        var subjectEndpoint = subjectEndpoints.ShouldHaveSingleItem();
        subjectEndpoint.Name.ShouldBe("StudentUSI");
        subjectEndpoint.Value.ShouldBe(100);
        subjectEndpoint.AuthorizationPathModifier.ShouldBe(IncludingDeletes);
    }

    [Test]
    public void GetAuthorizationSubjectEndpoints_ShouldReturnOnlyStudentEndpoint_WhenContextContainsStudentAndParent()
    {
        // Arrange
        var strategy = new TestableStrategy(_domainModelProvider, _personEntitySpecification);

        var authorizationContextTuples = new (string name, object value)[]
        {
            ("StudentUSI", 100),
            ("ParentUSI", 300),
        };

        // Act
        var subjectEndpoints = strategy.GetSubjectEndpoints(authorizationContextTuples);

        // Assert
        var subjectEndpoint = subjectEndpoints.ShouldHaveSingleItem();
        subjectEndpoint.Name.ShouldBe("StudentUSI");
        subjectEndpoint.Value.ShouldBe(100);
        subjectEndpoint.AuthorizationPathModifier.ShouldBe(IncludingDeletes);
    }

    [Test]
    public void GetAuthorizationStrategyFiltering_ShouldProduceOnlyStudentIncludingDeletesFilter_ForStudentContactAssociation()
    {
        // Arrange
        A.CallTo(() => _domainModelProvider.GetDomainModel())
            .Returns(CreateStudentContactAssociationDomainModel());

        var contextDataProvider = A.Fake<IRelationshipsAuthorizationContextDataProvider>();

        A.CallTo(() => contextDataProvider.GetAuthorizationContextPropertyNames())
            .Returns(new[] { "StudentUSI", "ContactUSI" });

        var contextDataProviderFactory = A.Fake<IRelationshipsAuthorizationContextDataProviderFactory>();

        A.CallTo(() => contextDataProviderFactory.GetProvider(A<Type>.Ignored))
            .Returns(contextDataProvider);

        var strategy = new RelationshipsWithStudentsOnlyIncludingDeletesAuthorizationStrategy(
            _domainModelProvider,
            _personEntitySpecification)
        {
            RelationshipsAuthorizationContextDataProviderFactory = contextDataProviderFactory
        };

        // Simulates a multiple-item (e.g. /deletes) request -- no entity data, only the entity type.
        var authorizationContext = new DataManagementRequestContext(
            ApiClientContextHelper.GetApiClientContextWithEdOrgIds(255901L),
            new Resource("StudentContactAssociation"),
            new[] { "studentContactAssociations" },
            "ReadChanges",
            typeof(StudentContactAssociation));

        // Act
        var filtering = strategy.GetAuthorizationStrategyFiltering(
            Array.Empty<ClaimSetResourceClaimMetadata>(),
            authorizationContext);

        // Assert
        var filter = filtering.Filters.ShouldHaveSingleItem();
        filter.SubjectEndpointName.ShouldBe("StudentUSI");
        filter.FilterName.ShouldBe($"{RelationshipAuthorizationConventions.FilterNamePrefix}ToStudentUSI{IncludingDeletes}");
        filtering.Filters.Select(f => f.FilterName).ShouldNotContain(f => f.Contains("ContactUSI"));
    }

    /// <summary>
    /// Exposes the protected <see cref="RelationshipsAuthorizationStrategyBase.GetAuthorizationSubjectEndpoints"/> method for testing.
    /// </summary>
    private class TestableStrategy : RelationshipsWithStudentsOnlyIncludingDeletesAuthorizationStrategy
    {
        public TestableStrategy(
            IDomainModelProvider domainModelProvider,
            IPersonEntitySpecification personEntitySpecification)
            : base(domainModelProvider, personEntitySpecification) { }

        public SubjectEndpoint[] GetSubjectEndpoints(IEnumerable<(string name, object value)> authorizationContextTuples)
        {
            return GetAuthorizationSubjectEndpoints(authorizationContextTuples);
        }
    }

    [Schema("edfi")]
    private class StudentContactAssociation
    {
        public int StudentUSI { get; set; }

        public int ContactUSI { get; set; }
    }

    private static DomainModel CreateStudentContactAssociationDomainModel()
    {
        var entityDefinitions = new[]
        {
            new EntityDefinition(
                "edfi",
                nameof(StudentContactAssociation),
                new[]
                {
                    new EntityPropertyDefinition("StudentUSI", new PropertyType(DbType.Int32)),
                    new EntityPropertyDefinition("ContactUSI", new PropertyType(DbType.Int32)),
                },
                Array.Empty<EntityIdentifierDefinition>())
        };

        var aggregateDefinitions = new[]
        {
            new AggregateDefinition(
                new FullName("edfi", nameof(StudentContactAssociation)),
                Array.Empty<FullName>())
        };

        var modelDefinitions = new DomainModelDefinitions(
            new SchemaDefinition("Ed-Fi", "edfi"),
            aggregateDefinitions,
            entityDefinitions,
            Array.Empty<AssociationDefinition>());

        var builder = new DomainModelBuilder();
        builder.AddDomainModelDefinitionsList(new List<DomainModelDefinitions> { modelDefinitions });

        return builder.Build();
    }
}
