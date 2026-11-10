// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using EdFi.Ods.Api.Security.Authorization.Filtering;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Infrastructure.Filtering;
using EdFi.Ods.Common.Models.Definitions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Models.Resource;
using EdFi.Ods.Common.Security.Authorization;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Ods.Entities.NHibernate.StudentAggregate.EdFi;
using EdFi.Ods.Features.Composites;
using EdFi.Ods.Features.Composites.Infrastructure;
using FakeItEasy;
using NUnit.Framework;
using Shouldly;

namespace EdFi.Ods.Tests.EdFi.Ods.Features.Composites;

[TestFixture]
public class HqlBuilderAuthorizationDecoratorTests
{
    [SetUp]
    public void SetUp()
    {
        _next = A.Fake<ICompositeItemBuilder<HqlBuilderContext, CompositeQuery>>();
        _authPlanFactory = A.Fake<IDataManagementAuthorizationPlanFactory>();
        _filterDefProvider = A.Fake<IAuthorizationFilterDefinitionProvider>();
        _authContextProvider = A.Fake<IAuthorizationContextProvider>();

        _decorator = new HqlBuilderAuthorizationDecorator(_next, _authPlanFactory, _filterDefProvider, _authContextProvider);
    }

    private ICompositeItemBuilder<HqlBuilderContext, CompositeQuery> _next;
    private IDataManagementAuthorizationPlanFactory _authPlanFactory;
    private IAuthorizationFilterDefinitionProvider _filterDefProvider;
    private IAuthorizationContextProvider _authContextProvider;
    private HqlBuilderAuthorizationDecorator _decorator;

    [Test]
    public void TryIncludeResource_WithNonResourceClass_ThrowsInvalidOperationException()
    {
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(new NotARootResource("xyz"));

        Should.Throw<InvalidOperationException>(
            () => _decorator.TryIncludeResource(processorContext, CreateMinimalBuilderContext()));
    }

    [Test]
    public void TryIncludeResource_WithAuthorizationFailureOnBaseResource_ThrowsException()
    {
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = CreateStudentResource();
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);
        A.CallTo(() => processorContext.IsBaseResource()).Returns(true);

        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri))
            .Throws(new SecurityAuthorizationException("detail", "error"));

        Should.Throw<SecurityAuthorizationException>(
            () => _decorator.TryIncludeResource(processorContext, CreateMinimalBuilderContext()));
    }
    
    [Test]
    public void TryIncludeResource_WithAbstractResourceAndSubtypeIncluded_ReturnsTrue()
    {
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = new Resource("xyz");
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);
        A.CallTo(() => processorContext.IsAbstract()).Returns(true);
        A.CallTo(() => processorContext.ShouldIncludeResourceSubtype()).Returns(true);

        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri))
            .Throws(new SecurityAuthorizationException("detail", "error"));

        var result = _decorator.TryIncludeResource(processorContext, CreateMinimalBuilderContext());

        result.ShouldBeTrue();
    }

    [Test]
    public void TryIncludeResource_WithAbstractResourceAndSubtypeNotIncluded_ReturnsFalse()
    {
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = new Resource("xyz");
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);
        A.CallTo(() => processorContext.IsAbstract()).Returns(true);
        A.CallTo(() => processorContext.ShouldIncludeResourceSubtype()).Returns(false);

        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri))
            .Throws(new SecurityAuthorizationException("detail", "error"));

        var result = _decorator.TryIncludeResource(processorContext, CreateMinimalBuilderContext());

        result.ShouldBeFalse();
    }

    [Test]
    public void TryIncludeResource_WithAuthorizedResourceWithOneAuthorizationFilterMissingHql_ThrowsSecurityConfigurationException()
    {
        // Arrange
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = new Resource("xyz");
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);

        var filter1Definition = new AuthorizationFilterDefinition("filter1", "some-hql", null, null, null);
        var filter2Definition = new AuthorizationFilterDefinition("filter2", null, null, null, null);
        var filter3Definition = new AuthorizationFilterDefinition("filter3", "more-hql", null, null, null);

        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition("filter1", out filter1Definition));
        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition("filter2", out filter2Definition));
        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition("filter3", out filter3Definition));

        var filtering = new AuthorizationStrategyFiltering[]
        {
            new ()
            {
                Filters = [
                    new AuthorizationFilterContext { FilterName = "filter1" },
                    new AuthorizationFilterContext { FilterName = "filter2" },
                    new AuthorizationFilterContext { FilterName = "filter3" },
                ]
            }
        };
        
        var dataManagementAuthorizationPlan = new DataManagementAuthorizationPlan()
        {
            AuthorizationBasisMetadata = null,
            Filtering = filtering,
            RequestContext = null,
        };
        
        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri))
            .Returns(dataManagementAuthorizationPlan);
        
        // Act / Assert
        var exception = Should.Throw<SecurityConfigurationException>(() => _decorator.TryIncludeResource(processorContext, CreateMinimalBuilderContext()));

        var problemDetails = exception as IEdFiProblemDetails;
        problemDetails.Errors[0].ShouldBe($"The request cannot be authorized because an authorization strategy has been used for the '{resource.FullName}' resource that does not support Composites requests. Should a different authorization strategy be used?");
    }

    [Test]
    public void TryIncludeResource_WithAuthorizedResource_SetsFiltering()
    {
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = new Resource("xyz");
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);

        var filter1Definition = new AuthorizationFilterDefinition("filter1", "some-hql", null, null, null);
        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition("filter1", out filter1Definition));

        var filtering = new AuthorizationStrategyFiltering[]
        {
            new ()
            {
                Filters = [
                    new AuthorizationFilterContext { FilterName = "filter1" },
                ]
            }
        };

        var authorizationPlan = new DataManagementAuthorizationPlan()
        {
            AuthorizationBasisMetadata = null,
            Filtering = filtering,
            RequestContext = null,
        };

        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri)).Returns(authorizationPlan);

        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition("filter1", out filter1Definition))
            .Returns(true);

        var builderContext = CreateMinimalBuilderContext();

        var result = _decorator.TryIncludeResource(processorContext, builderContext);

        result.ShouldBeTrue();
        builderContext.CurrentQueryAuthorizationFiltering.ShouldBe(filtering);
    }

    private const string RelationshipFilterName = "RelationshipFilter";
    private const string NamespaceFilterName = "NamespaceFilter";
    private const string OwnershipFilterName = "OwnershipFilter";

    private void RegisterFilterDefinitions()
    {
        var relationshipDefinition = new AuthorizationFilterDefinition(
            RelationshipFilterName,
            "{currentAlias}.{subjectEndpointName} IN (SELECT {newAlias1}.TargetEducationOrganizationId FROM auth_EdOrgToEdOrg {newAlias1} WHERE {newAlias1}.SourceEducationOrganizationId IN (:ClaimEducationOrganizationIds))",
            null, null, null);

        var namespaceDefinition = new AuthorizationFilterDefinition(
            NamespaceFilterName,
            "({currentAlias}.{subjectEndpointName} IS NOT NULL AND {currentAlias}.{subjectEndpointName} LIKE :Namespace)",
            null, null, null);

        var ownershipDefinition = new AuthorizationFilterDefinition(
            OwnershipFilterName,
            "({currentAlias}.CreatedByOwnershipTokenId IS NOT NULL AND {currentAlias}.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))",
            null, null, null);

        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition(RelationshipFilterName, out relationshipDefinition))
            .Returns(true)
            .AssignsOutAndRefParameters(relationshipDefinition);

        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition(NamespaceFilterName, out namespaceDefinition))
            .Returns(true)
            .AssignsOutAndRefParameters(namespaceDefinition);

        A.CallTo(() => _filterDefProvider.TryGetAuthorizationFilterDefinition(OwnershipFilterName, out ownershipDefinition))
            .Returns(true)
            .AssignsOutAndRefParameters(ownershipDefinition);
    }

    private static AuthorizationFilterContext RelationshipFilter(params object[] claimEducationOrganizationIds)
        => new()
        {
            FilterName = RelationshipFilterName,
            SubjectEndpointName = "SchoolId",
            ClaimParameterName = "ClaimEducationOrganizationIds",
            ClaimEndpointValues = claimEducationOrganizationIds,
        };

    private static AuthorizationFilterContext NamespaceFilter(string namespacePrefix)
        => new()
        {
            FilterName = NamespaceFilterName,
            SubjectEndpointName = "Namespace",
            ClaimParameterName = "Namespace",
            ClaimEndpointValues = [namespacePrefix],
        };

    private static AuthorizationFilterContext OwnershipFilter(params object[] ownershipTokenIds)
        => new()
        {
            FilterName = OwnershipFilterName,
            ClaimParameterName = "CreatedByOwnershipTokenId",
            ClaimEndpointValues = ownershipTokenIds,
        };

    private static HqlBuilderContext CreateFlattenedReferenceBuilderContext(params AuthorizationStrategyFiltering[] filtering)
        => CreateFlattenedReferenceBuilderContext(isFlattenedMemberContext: true, filtering);

    private static HqlBuilderContext CreateFlattenedReferenceBuilderContext(
        bool isFlattenedMemberContext,
        params AuthorizationStrategyFiltering[] filtering)
    {
        var builderContext = new HqlBuilderContext(
            new StringBuilder("comp_aa.Id As __BaseEntityId__"),
            new StringBuilder("\tSectionQ comp_aa\n\tjoin comp_aa.CourseOffering comp_ab"),
            null,
            null,
            null,
            "comp_aa",
            int.MinValue,
            null,
            null,
            null,
            new AliasGenerator("comp_"))
        {
            IsFlattenedMemberContext = isFlattenedMemberContext,
            CurrentAlias = "comp_ab",
            CurrentQueryAuthorizationFiltering = filtering
        };

        return builderContext;
    }

    [Test]
    public void ApplyFlattenedMember_ForChildQueryJoinPath_DoesNotProjectAnAuthorizationFlag()
    {
        // Arrange
        RegisterFilterDefinitions();

        // Flattened references are also applied to child query contexts to join to (non-flattened) references they
        // contain. The filtering on such a context belongs to the containing member, not to the member being applied.
        var builderContext = CreateFlattenedReferenceBuilderContext(
            isFlattenedMemberContext: false,
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901)]
            });

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        A.CallTo(() => _next.ApplyFlattenedMember(null, builderContext)).MustHaveHappenedOnceExactly();
        builderContext.Select.ToString().ShouldBe("comp_aa.Id As __BaseEntityId__");
        builderContext.AuthorizationFlagAlias.ShouldBeNull();
        builderContext.CurrentQueryFilterParameterValueByName.ShouldBeEmpty();
    }

    [Test]
    public void ApplyFlattenedMember_WithRelationshipFiltering_ProjectsAuthorizationFlagWithoutFilteringRows()
    {
        // Arrange
        RegisterFilterDefinitions();

        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901)]
            });

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        A.CallTo(() => _next.ApplyFlattenedMember(null, builderContext)).MustHaveHappenedOnceExactly();

        string select = builderContext.Select.ToString();

        select.ShouldStartWith("comp_aa.Id As __BaseEntityId__,");
        select.ShouldContain("case when (( (comp_ab.SchoolId IN (SELECT ");
        select.ShouldContain("IN (:ClaimEducationOrganizationIds))))) then 1 else 0 end as __Auth_comp_ab");

        builderContext.AuthorizationFlagAlias.ShouldBe("__Auth_comp_ab");
        builderContext.Where.ShouldBeNull();

        // A single claim value is bound as a scalar, as it is for the root query
        builderContext.CurrentQueryFilterParameterValueByName["ClaimEducationOrganizationIds"].ShouldBe(255901);
    }

    [Test]
    public void ApplyFlattenedMember_WithStrategiesCombinedWithAndAndOrLogic_CombinesPredicatesLikeTheRootQuery()
    {
        // Arrange
        RegisterFilterDefinitions();

        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.And,
                Filters = [OwnershipFilter((short) 1, (short) 2)]
            },
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [NamespaceFilter("uri://ed-fi.org%")]
            },
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901, 255902)]
            });

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        string select = builderContext.Select.ToString();

        select.ShouldContain(
            "case when (((comp_ab.CreatedByOwnershipTokenId IS NOT NULL AND comp_ab.CreatedByOwnershipTokenId IN (:CreatedByOwnershipTokenId))) AND ( ((comp_ab.Namespace IS NOT NULL AND comp_ab.Namespace LIKE :Namespace)) OR  (comp_ab.SchoolId IN (SELECT ");

        select.ShouldEndWith(") then 1 else 0 end as __Auth_comp_ab");

        var parameters = builderContext.CurrentQueryFilterParameterValueByName;
        parameters["CreatedByOwnershipTokenId"].ShouldBe(new object[] { (short) 1, (short) 2 });
        parameters["Namespace"].ShouldBe("uri://ed-fi.org%");
        parameters["ClaimEducationOrganizationIds"].ShouldBe(new object[] { 255901, 255902 });
    }

    [Test]
    public void ApplyFlattenedMember_WithParameterAlreadyCapturedWithSameValue_ReusesTheParameter()
    {
        // Arrange
        RegisterFilterDefinitions();

        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901, 255902)]
            });

        builderContext.CurrentQueryFilterParameterValueByName["ClaimEducationOrganizationIds"] = new object[] { 255901, 255902 };

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        builderContext.Select.ToString().ShouldContain("IN (:ClaimEducationOrganizationIds))");
        builderContext.CurrentQueryFilterParameterValueByName.Count.ShouldBe(1);
    }

    [Test]
    public void ApplyFlattenedMember_WithParameterAlreadyCapturedWithDifferentValue_UsesADistinctParameterName()
    {
        // Arrange
        RegisterFilterDefinitions();

        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [NamespaceFilter("uri://ed-fi.org%")]
            });

        // e.g. a query string criteria value for a "Namespace" property of the base resource
        builderContext.CurrentQueryFilterParameterValueByName["Namespace"] = "uri://somewhere-else.org/x";

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        string select = builderContext.Select.ToString();

        select.ShouldContain("comp_ab.Namespace LIKE :Namespace_comp_ab)");
        select.ShouldNotContain(":Namespace)");

        builderContext.CurrentQueryFilterParameterValueByName["Namespace"].ShouldBe("uri://somewhere-else.org/x");
        builderContext.CurrentQueryFilterParameterValueByName["Namespace_comp_ab"].ShouldBe("uri://ed-fi.org%");
    }

    [Test]
    public void ApplyFlattenedMember_WithNoFiltering_DoesNotProjectAnAuthorizationFlag()
    {
        // Arrange
        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = []
            });

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        builderContext.Select.ToString().ShouldBe("comp_aa.Id As __BaseEntityId__");
        builderContext.AuthorizationFlagAlias.ShouldBeNull();
        builderContext.CurrentQueryFilterParameterValueByName.ShouldBeEmpty();
    }

    [Test]
    public void ApplyFlattenedMember_WithoutAuthorizationPlan_DoesNotProjectAnAuthorizationFlag()
    {
        // Arrange (e.g. an abstract reference with 'includeResourceSubtype')
        var builderContext = CreateFlattenedReferenceBuilderContext(null);

        // Act
        _decorator.ApplyFlattenedMember(null, builderContext);

        // Assert
        builderContext.Select.ToString().ShouldBe("comp_aa.Id As __BaseEntityId__");
        builderContext.AuthorizationFlagAlias.ShouldBeNull();
    }

    [Test]
    public void ApplyFlattenedMember_WithEmbeddedObject_DoesNotProjectAnAuthorizationFlag()
    {
        // Arrange
        RegisterFilterDefinitions();

        // Filtering for the containing resource is present on the context for flattened embedded objects
        var builderContext = CreateFlattenedReferenceBuilderContext(
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901)]
            });

        var embeddedObject = new EmbeddedObject(new Resource("Section"), null, "SomeEmbeddedObject");

        // Act
        _decorator.ApplyFlattenedMember(embeddedObject, builderContext);

        // Assert
        A.CallTo(() => _next.ApplyFlattenedMember(embeddedObject, builderContext)).MustHaveHappenedOnceExactly();
        builderContext.Select.ToString().ShouldBe("comp_aa.Id As __BaseEntityId__");
        builderContext.AuthorizationFlagAlias.ShouldBeNull();
    }

    [Test]
    public void BuildForChildResource_WithFiltering_AppliesFiltersToTheWhereClause()
    {
        // Arrange
        RegisterFilterDefinitions();

        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(new Resource("CourseOffering"));

        var builderContext = new HqlBuilderContext(
            new StringBuilder("comp_aa.Id As __BaseEntityId__"),
            new StringBuilder(),
            new StringBuilder("comp_aa.Id IN (:BaseEntityId)"),
            new StringBuilder())
        {
            CurrentAlias = "comp_ab",
            CurrentQueryAuthorizationFiltering =
            [
                new AuthorizationStrategyFiltering
                {
                    Operator = FilterOperator.Or,
                    Filters = [RelationshipFilter(255901)]
                }
            ]
        };

        // Act
        _decorator.BuildForChildResource(null, builderContext, processorContext);

        // Assert
        string where = builderContext.Where.ToString();

        where.ShouldStartWith("comp_aa.Id IN (:BaseEntityId) AND ( (comp_ab.SchoolId IN (SELECT ");
        where.ShouldEndWith("IN (:ClaimEducationOrganizationIds))))");
        builderContext.Select.ToString().ShouldBe("comp_aa.Id As __BaseEntityId__");
        builderContext.CurrentQueryFilterParameterValueByName["ClaimEducationOrganizationIds"].ShouldBe(255901);
    }

    private (CompositeDefinitionProcessorContext processorContext, AuthorizationStrategyFiltering[] filtering)
        ArrangeAuthorizedResource(string resourceName)
    {
        RegisterFilterDefinitions();

        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var resource = new Resource(resourceName);
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(resource);

        var filtering = new[]
        {
            new AuthorizationStrategyFiltering
            {
                Operator = FilterOperator.Or,
                Filters = [RelationshipFilter(255901)]
            }
        };

        A.CallTo(() => _authPlanFactory.CreateAuthorizationPlan(resource, RequestActions.ReadActionUri))
            .Returns(new DataManagementAuthorizationPlan { Filtering = filtering });

        return (processorContext, filtering);
    }

    [Test]
    public void TryIncludeResource_ForFlattenedReferenceChildContext_CapturesTheFilteringForTheReferencesChildQueries()
    {
        // Arrange
        var (processorContext, filtering) = ArrangeAuthorizedResource("Student");

        var outerReferenceAuthorization = new ContainingReferenceAuthorizationFiltering([], "comp_ab");

        // The referenced resource's alias is the context's parent alias (as set by CreateFlattenedReferenceChildContext)
        var builderContext = new HqlBuilderContext(
            new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder(),
            null, "comp_ac", 1, null, null, null, new AliasGenerator("comp_"))
        {
            IsFlattenedReferenceChildContext = true,
            ContainingReferenceAuthorizations = [outerReferenceAuthorization]
        };

        // Act
        var result = _decorator.TryIncludeResource(processorContext, builderContext);

        // Assert
        result.ShouldBeTrue();

        builderContext.ContainingReferenceAuthorizations.Count.ShouldBe(2);
        builderContext.ContainingReferenceAuthorizations[0].ShouldBeSameAs(outerReferenceAuthorization);
        builderContext.ContainingReferenceAuthorizations[1].Filtering.ShouldBeSameAs(filtering);
        builderContext.ContainingReferenceAuthorizations[1].Alias.ShouldBe("comp_ac");
    }

    [Test]
    public void TryIncludeResource_ForResourceThatIsNotFlattened_ClearsTheFilteringOfContainingFlattenedReferences()
    {
        // Arrange (e.g. a reference that is not flattened, contained by a flattened reference)
        var (processorContext, _) = ArrangeAuthorizedResource("Session");

        var builderContext = CreateMinimalBuilderContext();
        builderContext.ContainingReferenceAuthorizations = [new ContainingReferenceAuthorizationFiltering([], "comp_ab")];

        // Act
        var result = _decorator.TryIncludeResource(processorContext, builderContext);

        // Assert (the resource is authorized on its own)
        result.ShouldBeTrue();
        builderContext.ContainingReferenceAuthorizations.ShouldBeEmpty();
    }

    [Test]
    public void BuildForChildResource_ForMemberOfFlattenedReference_AppliesTheReferencesFiltersToTheWhereClause()
    {
        // Arrange
        RegisterFilterDefinitions();

        // e.g. <ReferencedResource name="StudentReference" flatten="true"><Collection name="StudentOtherNames" />
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        A.CallTo(() => processorContext.CurrentResourceClass)
            .Returns(new ResourceChildItem("StudentOtherName", new Resource("Student")));

        var builderContext = new HqlBuilderContext(
            new StringBuilder("comp_aa.Id As __BaseEntityId__"),
            new StringBuilder(),
            new StringBuilder("comp_aa.Id IN (:BaseEntityId)"),
            new StringBuilder())
        {
            CurrentAlias = "comp_ac",
            ContainingReferenceAuthorizations =
            [
                new ContainingReferenceAuthorizationFiltering(
                    [
                        new AuthorizationStrategyFiltering
                        {
                            Operator = FilterOperator.Or,
                            Filters = [RelationshipFilter(255901, 255902)]
                        }
                    ],
                    "comp_ab")
            ]
        };

        // Act
        _decorator.BuildForChildResource(null, builderContext, processorContext);

        // Assert (the rows are only returned when the client is authorized to read the referenced resource)
        string where = builderContext.Where.ToString();

        where.ShouldStartWith("comp_aa.Id IN (:BaseEntityId) AND ( (comp_ab.SchoolId IN (SELECT ");
        where.ShouldEndWith("IN (:ClaimEducationOrganizationIds))))");
        builderContext.CurrentQueryFilterParameterValueByName["ClaimEducationOrganizationIds"]
            .ShouldBe(new object[] { 255901, 255902 });

        A.CallTo(() => _next.BuildForChildResource(null, builderContext, processorContext)).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void BuildForChildResource_ForResourceWithinFlattenedReference_DoesNotApplyTheReferencesFilters()
    {
        // Arrange
        RegisterFilterDefinitions();

        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(new Resource("Session"));

        var builderContext = new HqlBuilderContext(
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder("comp_aa.Id IN (:BaseEntityId)"),
            new StringBuilder())
        {
            CurrentAlias = "comp_ac",
            CurrentQueryAuthorizationFiltering = [],
            ContainingReferenceAuthorizations =
            [
                new ContainingReferenceAuthorizationFiltering(
                    [
                        new AuthorizationStrategyFiltering
                        {
                            Operator = FilterOperator.Or,
                            Filters = [RelationshipFilter(255901)]
                        }
                    ],
                    "comp_ab")
            ]
        };

        // Act
        _decorator.BuildForChildResource(null, builderContext, processorContext);

        // Assert
        builderContext.Where.ToString().ShouldBe("comp_aa.Id IN (:BaseEntityId)");
        builderContext.CurrentQueryFilterParameterValueByName.ShouldBeEmpty();
    }

    [Test]
    public void TryBuildForRootResource_WithParameterAlreadyUsedWithDifferentValue_UsesADistinctParameterName()
    {
        // Arrange
        RegisterFilterDefinitions();

        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        A.CallTo(() => processorContext.CurrentResourceClass).Returns(new Resource("Assessment"));

        var builderContext = new HqlBuilderContext(
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder(),
            new StringBuilder())
        {
            CurrentAlias = "comp_aa",
            CurrentQueryAuthorizationFiltering =
            [
                new AuthorizationStrategyFiltering
                {
                    Operator = FilterOperator.Or,
                    Filters = [NamespaceFilter("uri://ed-fi.org%")]
                }
            ]
        };

        // e.g. criteria from the query string (?namespace=...), or a flattened reference's authorization flag
        builderContext.CurrentQueryFilterParameterValueByName["Namespace"] = "uri://ed-fi.org/Assessment";

        // Act
        _decorator.TryBuildForRootResource(builderContext, processorContext, out _);

        // Assert
        builderContext.Where.ToString().ShouldContain("comp_aa.Namespace LIKE :Namespace_comp_aa)");
        builderContext.CurrentQueryFilterParameterValueByName["Namespace"].ShouldBe("uri://ed-fi.org/Assessment");
        builderContext.CurrentQueryFilterParameterValueByName["Namespace_comp_aa"].ShouldBe("uri://ed-fi.org%");
    }

    /*
    [Test]
    public void TryBuildForRootResource_WithFilters_CallsNext()
    {
        var builderContext = CreateMinimalBuilderContext();
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();
        var buildResult = new CompositeQuery();

        A.CallTo(() => _next.TryBuildForRootResource(builderContext, processorContext, out buildResult))
            .Returns(true);

        var result = _decorator.TryBuildForRootResource(builderContext, processorContext, out var outputResult);

        result.ShouldBeTrue();
        outputResult.ShouldBe(buildResult);

        A.CallTo(() => _next.TryBuildForRootResource(builderContext, processorContext, out buildResult))
            .MustHaveHappenedOnceExactly();
    }

    [Test]
    public void BuildForChildResource_WithFilters_CallsNext()
    {
        var parentResult = new CompositeQuery();
        var builderContext = new HqlBuilderContext();
        var processorContext = A.Fake<CompositeDefinitionProcessorContext>();

        A.CallTo(() => _next.BuildForChildResource(parentResult, builderContext, processorContext))
            .Returns(parentResult);

        var result = _decorator.BuildForChildResource(parentResult, builderContext, processorContext);

        result.ShouldBe(parentResult);

        A.CallTo(() => _next.BuildForChildResource(parentResult, builderContext, processorContext))
            .MustHaveHappenedOnceExactly();
    }
    */

    /// <summary>
    /// Creates a Student resource with the necessary Entity and Aggregate instances to obtain the correct name.
    /// </summary>
    /// <returns></returns>
    private static Resource CreateStudentResource()
    {
        var domainModelBuilder = new DomainModelBuilder();

        var schema = EdFiConventions.PhysicalSchemaName;

        var entityName = new FullName(schema, "Student");

        domainModelBuilder.AddAggregate(new AggregateDefinition(entityName, Array.Empty<FullName>()));

        domainModelBuilder.AddEntity(
            new EntityDefinition(
                schema,
                "Student",
                Array.Empty<EntityPropertyDefinition>(),
                Array.Empty<EntityIdentifierDefinition>()));

        domainModelBuilder.AddSchema(new SchemaDefinition(EdFiConventions.LogicalName, schema));

        var domainModel = domainModelBuilder.Build();

        var resourceModel = new ResourceModel(domainModel);

        var entity = domainModel.EntityByFullName[entityName];

        // Apply the domain model enhancer dynamic property
        (entity as dynamic).NHibernateEntityType = typeof(Student);

        // Create the Resource using the Entity
        var resource = (Resource)Activator.CreateInstance(
            typeof(Resource),
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new object[]
            {
                resourceModel,
                entity
            },
            CultureInfo.CurrentCulture);

        return resource;
    }

    // private CompositeDefinitionProcessorContext GetCompositeDefinitionProcessorContext(ResourceClassBase resourceClass = null)
    // {
    //     resourceClass ??= CreateStudentResource();
    //
    //     return new CompositeDefinitionProcessorContext(
    //         null,
    //         null,
    //         new XElement("BaseResource"),
    //         resourceClass,
    //         null,
    //         null,
    //         null,
    //         int.MinValue,
    //         null);
    // }

    private class NotARootResource : ResourceClassBase
    {
        internal NotARootResource(string name)
            : base(name) { }

        public override bool IsResourceExtension { get; }

        public override bool IsResourceExtensionClass { get; }

        public override Resource ResourceRoot { get; }

        public override string JsonPath { get; }
    }

    private static HqlBuilderContext CreateMinimalBuilderContext()
        => new(new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder());
}
