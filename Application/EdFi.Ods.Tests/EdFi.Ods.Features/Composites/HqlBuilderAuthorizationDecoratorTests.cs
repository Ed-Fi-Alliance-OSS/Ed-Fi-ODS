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
